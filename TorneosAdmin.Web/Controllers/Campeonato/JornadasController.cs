using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public JsonResult ObtenerJornadas(string si1dx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var jornadasLista = _context.Jornadas.Select(x => new
            {
                x.ID,
                x.CampeonatoID,
                x.CategoriaID,
                x.SerieID,
                x.PartidoID,
                x.EquipoIDLocal,
                x.EquipoIDVisita,
                x.GrupoJornada
            });
            int totalRecords = jornadasLista.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sort.ToUpper() == "DESC")
            {
                jornadasLista = jornadasLista.OrderByDescending(t => t.ID);
                jornadasLista = jornadasLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                jornadasLista = jornadasLista.OrderBy(t => t.ID);
                jornadasLista = jornadasLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = jornadasLista
            };
            return Json(jsonData);
        }

        //[NonAction]
        //public void CargaInicial(string serieEquipo, int id_Campeonato, DateTime fechaInicial)
        //{
        //    // Obtenemos los equipos
        //    var equipos = _context.Equipo.Where(e => e.serie == serieEquipo).ToList();

        //    // Colocamos todos los id de equipos en una matriz
        //    int indice = 0;
        //    int[] matriz = new int[equipos.Count()];
        //    equipos.ForEach(delegate (Equipo equipo)
        //    {
        //        matriz[indice] = equipo.Id_Equipo;
        //        indice++;
        //    });


        //    // Se calcula el numero de fechas a realizarse
        //    int fechas = equipos.Count();
        //    if ((fechas) % 2 == 0)
        //    {
        //        //Si es numero impar el total de equipos se resta 1
        //        fechas = fechas - 1;
        //    }

        //    // Obtenemos el primer sabado para serie A y domingo para la serie B con las 8 horas
        //    if (serieEquipo == "A")
        //        fechaInicial = fechaInicial.AddDays(6 - (int)fechaInicial.DayOfWeek).AddHours(8);
        //    else
        //        fechaInicial = fechaInicial.AddDays(7 - (int)fechaInicial.DayOfWeek).AddHours(8);

        //    //Pasamos todas las jornadas
        //    for (int x = 1; x <= fechas; x++)
        //    {
        //        int i = 0;

        //        // Insertamos en base de datos los registros de las jornadas
        //        for (int j = equipos.Count() - 1; i < j; j--)
        //        {
        //            // Creamos el partido primero
        //            Partido partido = new Partido();
        //            partido.FechaHora = fechaInicial;
        //            _context.Partido.Add(partido);
        //            _context.SaveChanges();

        //            //Creamos la jornada y pasamos el id del partido
        //            Jornadas jornadas = new Jornadas()
        //            {
        //                // Le asignamos valores a la jornada
        //                idCampeonato = id_Campeonato,
        //                idPartido = partido.id_partido,
        //                equipoLocal = matriz[i],
        //                equipoVisita = matriz[j],
        //                serie = serieEquipo,
        //                fecha = x
        //            };

        //            _context.Jornadas.Add(jornadas);
        //            _context.SaveChanges();

        //            // Por cada partido agregamos 2 horas.
        //            fechaInicial = fechaInicial.AddHours(2);
        //            i++;
        //        }

        //        // Se reacomoda la matriz para que el segundo pase a ser el ultimo
        //        int ultimaPosicion = matriz[equipos.Count() - 1];
        //        for (int y = equipos.Count() - 1; y > 1; y--)
        //        {
        //            matriz[y] = matriz[y - 1];
        //        }
        //        matriz[1] = ultimaPosicion;

        //        // Reiniciamos el contador de i para nuevamente tomar la primera posición en la tabla
        //        i = 0;

        //        // Intercambiamos los sabados y domingos, y configurando que sean las 8 de la mañana
        //        fechaInicial = new DateTime(fechaInicial.Year, fechaInicial.Month, fechaInicial.Day, 8, 0, 0);
        //        fechaInicial = fechaInicial.AddDays(7);
        //        if (x % 2 == 0)
        //        {
        //            if (serieEquipo == "A")
        //                fechaInicial = fechaInicial.AddDays(7 - (int)fechaInicial.DayOfWeek);
        //            else
        //                fechaInicial = fechaInicial.AddDays(6 - (int)fechaInicial.DayOfWeek);
        //        }
        //        else
        //        {
        //            if (serieEquipo == "A")
        //                fechaInicial = fechaInicial.AddDays(6 - (int)fechaInicial.DayOfWeek);
        //            else
        //                fechaInicial = fechaInicial.AddDays(7 - (int)fechaInicial.DayOfWeek);
        //        }
        //    }
        //}

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