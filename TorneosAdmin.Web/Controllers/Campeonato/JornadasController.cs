using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorneosAdmin.Web.Extensiones;
using TorneosAdmin.Web.Identidad;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers
{
    public class JornadasController : Controller
    {
        private readonly ModelEntities _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JornadasController(ModelEntities context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public JsonResult ObtenerJornadasVista(int campeonatoID, int categoriaId, int serieID )
        {
            var jornadasLista = from j in _context.Jornadas
                               join p in _context.Partidos on j.PartidoID equals p.ID
                               where j.CampeonatoID == campeonatoID && j.CategoriaID == categoriaId && j.SerieID == serieID
                               select new
                               {
                                   j.ID,
                                   j.EquipoIDLocal,
                                   j.EquipoIDVisita,
                                   j.GrupoJornada,
                                   j.Ronda,
                                   PartidoID = p.ID,
                                   FechaPartido = p.FechaHora.ToString("ddd", new CultureInfo("es-EC")) + " " + p.FechaHora.ToString("dd/MM/yyyy"),
                                   HoraPartido = p.FechaHora.ToString("HH:mm")
                               };
            return Json(jornadasLista);
        }

        [HttpPost]
        public IActionResult CargaInicial(JornadasCargaInicial jornadasCargaInicial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (jornadasCargaInicial.Dias[0] == null)
            {
                return BadRequest("Deben seleccionar al menos un dia a configurar.");
            }

            var juegos = _context.Jornadas.Where(x =>
                                                 x.CampeonatoID == jornadasCargaInicial.CampeonatoID &&
                                                 x.CategoriaID == jornadasCargaInicial.CategoriaID &&
                                                 x.SerieID == jornadasCargaInicial.SerieID &&
                                                 x.Ronda == jornadasCargaInicial.Ronda).ToList();
            if(juegos.Count>0)
                return BadRequest("Ya existe fechas configuradas.");

            try
            {
                // Obtenemos los dias
                int indice = 0;
                int[] dias = new int[jornadasCargaInicial.Dias.Count()];
                foreach (var item in jornadasCargaInicial.Dias)
                {
                    dias[indice] = Convert.ToInt32(item);
                    indice++;
                }

                // Obtenemos los equipos que se han inscripto en el campeonato
                var equipos = (from e in _context.Equipos
                               join i in _context.Inscripciones on e.ID equals i.EquipoID
                               where i.CampeonatoID == jornadasCargaInicial.CampeonatoID
                               select e).OrderBy(x=> x.ID).ToList();

                // Colocamos todos los id de equipos en una matriz
                indice = 0;
                int[] matriz = new int[equipos.Count()];
                equipos.ForEach(delegate (Equipos equipo)
                {
                    matriz[indice] = equipo.ID;
                    indice++;
                });


                // Se calcula el numero de fechas a realizarse
                int fechas = equipos.Count();
                if ((fechas) % 2 == 0)
                {
                    //Si es numero impar el total de equipos se resta 1
                    fechas = fechas - 1;
                }

                // Obtenemos primer dia de las jornadas.
                DateTime fechaInicial; 
                int dia = (int)jornadasCargaInicial.FechaInicial.DayOfWeek;
                if (dias.Contains(dia))
                {
                    fechaInicial = jornadasCargaInicial.FechaInicial.AddHours(jornadasCargaInicial.Hora);
                }
                else {
                    int i = dias.Max();
                    if (dia > i)
                        fechaInicial = jornadasCargaInicial.FechaInicial.AddDays(7 + (dias.Min() - dia)).AddHours(jornadasCargaInicial.Hora);
                    else {
                        i = 0;
                        for (int x = 0; x < dias.Length; x++)
                        {
                            if (dias[x] > dia)
                            {
                                i = dias[x];
                                break;
                            }
                        }
                        fechaInicial = jornadasCargaInicial.FechaInicial.AddDays(i - dia).AddHours(jornadasCargaInicial.Hora);
                    }
                }
                //Guardamos El dia que iniciamos
                dia = (int)fechaInicial.DayOfWeek;

                //Pasamos todas las jornadas
                for (int x = 1; x <= fechas; x++)
                {
                    int i = 0;

                    // Insertamos en base de datos los registros de las jornadas
                    for (int j = equipos.Count() - 1; i < j; j--)
                    {
                        // Creamos el partido primero
                        Partidos partido = new Partidos();
                        partido.PartidoEstadoID = 1;
                        partido.FechaHora = fechaInicial;
                        _context.Partidos.Add(partido);
                        _context.SaveChanges();

                        //Creamos la jornada y pasamos el id del partido
                        Jornadas jornadas = new Jornadas()
                        {
                            // Le asignamos valores a la jornada
                            CampeonatoID = jornadasCargaInicial.CampeonatoID,
                            PartidoID = partido.ID,
                            EquipoIDLocal = matriz[i],
                            EquipoIDVisita = matriz[j],
                            CategoriaID = jornadasCargaInicial.CategoriaID,
                            SerieID = jornadasCargaInicial.SerieID,
                            GrupoJornada = x,
                            Ronda = jornadasCargaInicial.Ronda
                        };

                        _context.Jornadas.Add(jornadas);
                        _context.SaveChanges();

                        // Por cada partido agregamos 2 horas.
                        fechaInicial = fechaInicial.AddHours(2);
                        i++;
                    }

                    // Se reacomoda la matriz para que el segundo pase a ser el ultimo
                    int ultimaPosicion = matriz[equipos.Count() - 1];
                    for (int y = equipos.Count() - 1; y > 1; y--)
                    {
                        matriz[y] = matriz[y - 1];
                    }
                    matriz[1] = ultimaPosicion;

                    // Reiniciamos el contador de i para nuevamente tomar la primera posición en la tabla
                    i = 0;

                    // Intercambiamos los dias seleccionados, y configurando que sean las 8 de la mañana
                    fechaInicial = fechaInicial.Date;

                    // Tomamos el indice del dia en arreglo del dias y nos pasamos al siguiente
                    int indexdias = Array.IndexOf(dias, dia) + 1;
                    dia = (int)fechaInicial.DayOfWeek;

                    // Si solo se tiene un dia en el arreglo hacemos el ciclo a la siguiente semana
                    if (dias.Length == 1)
                    {
                        if (dias[0] == 6)
                            fechaInicial = fechaInicial.AddDays(dias[0] - dia).AddHours(jornadasCargaInicial.Hora);
                        else
                            fechaInicial = fechaInicial.AddDays(7 + (dias[0] - dia)).AddHours(jornadasCargaInicial.Hora);
                    }
                    else
                    {
                        // Si se pasa del elementos del arreglo tomamos el primero
                        if (indexdias > (dias.Length - 1))
                            fechaInicial = fechaInicial.AddDays(7 + (dias[0] - dia)).AddHours(jornadasCargaInicial.Hora);
                        else
                        {
                            if (dias[indexdias - 1] == 0)
                                fechaInicial = fechaInicial.AddDays(dias[indexdias] - dia).AddHours(jornadasCargaInicial.Hora);
                            else
                                fechaInicial = fechaInicial.AddDays(7 + (dias[indexdias] - dia)).AddHours(jornadasCargaInicial.Hora);
                        }
                    }

                    //Guardamos para el siguiente ciclo
                    dia = (int)fechaInicial.DayOfWeek;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string errMsg = FormateadorCadenas.ObtenerMensajesErrores(ex);
                return BadRequest(errMsg);
            }
            catch (Exception ex)
            {
                string errMsg = FormateadorCadenas.ObtenerMensajesErrores(ex);
                return BadRequest(errMsg);
            }
            return Ok();
        }

        //// GET: Jornadas
        //public ActionResult Index()
        //{
        //    var jornadas = _context.Jornadas;
        //    return View(jornadas.ToList());

        //    //var modelo = _context.Equipo.Include(d => d.Jornadas);



        //}

        ////Jornadas calendario
        //public ActionResult JornadasA()
        //{
        //    List<Jornadas> jornadas = _context.Jornadas.Where(x => x.idCampeonato == _context.Campeonato.Max(y => y.Id_campeonato) && x.serie == "A").ToList();

        //    if (jornadas == null || jornadas.Count() == 0)
        //    {
        //        int idCampeonato = _context.Campeonato.Max(y => y.Id_campeonato);
        //        DateTime fecha = _context.Campeonato.Find(idCampeonato).fecha_ini;
        //        CargaInicial("A", idCampeonato, fecha);

        //        // llenamos jornadas nuevamente por la primera ves estuvo vacio.
        //        jornadas = _context.Jornadas.Where(x => x.idCampeonato == _context.Campeonato.Max(y => y.Id_campeonato) && x.serie == "A").ToList();
        //    }

        //    var tabla = from j in jornadas
        //                join p in _context.Partido on j.idPartido equals p.id_partido
        //                join local in _context.Equipo on j.equipoLocal equals local.Id_Equipo
        //                join visitante in _context.Equipo on j.equipoVisita equals visitante.Id_Equipo
        //                group new
        //                {
        //                    Fecha = j.fecha,
        //                    Local = local.nom_equipo,
        //                    LocalImagen = local.foto_equipo,
        //                    Visitante = visitante.nom_equipo,
        //                    VisitanteImagen = visitante.foto_equipo,
        //                    Hora = p.FechaHora.Value.ToString("HH:mm")
        //                } by j.fecha into jornadaPartido
        //                orderby jornadaPartido.Key
        //                select jornadaPartido;

        //    ViewBag.Jornadas = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(tabla));
        //    return View();

        //}

        ////Jornadas calendario
        //public ActionResult JornadasB()

        //{
        //    List<Jornadas> jornadas = _context.Jornadas.Where(x => x.idCampeonato == _context.Campeonato.Max(y => y.Id_campeonato) && x.serie == "B").ToList();

        //    if (jornadas == null || jornadas.Count() == 0)
        //    {
        //        int idCampeonato = _context.Campeonato.Max(y => y.Id_campeonato);
        //        DateTime fecha = _context.Campeonato.Find(idCampeonato).fecha_ini;
        //        CargaInicial("B", idCampeonato, fecha);

        //        // llenamos jornadas nuevamente por la primera ves estuvo vacio.
        //        jornadas = _context.Jornadas.Where(x => x.idCampeonato == _context.Campeonato.Max(y => y.Id_campeonato) && x.serie == "B").ToList();
        //    }

        //    var tabla = from j in jornadas
        //                join p in _context.Partido on j.idPartido equals p.id_partido
        //                join local in _context.Equipo on j.equipoLocal equals local.Id_Equipo
        //                join visitante in _context.Equipo on j.equipoVisita equals visitante.Id_Equipo
        //                group new
        //                {
        //                    Fecha = j.fecha,
        //                    Local = local.nom_equipo,
        //                    LocalImagen = local.foto_equipo,
        //                    Visitante = visitante.nom_equipo,
        //                    VisitanteImagen = visitante.foto_equipo,
        //                    Hora = p.FechaHora.Value.ToString("HH:mm")
        //                } by j.fecha into jornadaPartido
        //                orderby jornadaPartido.Key
        //                select jornadaPartido;

        //    ViewBag.Jornadas = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(tabla));

        //    return View();

        //}
    }
}