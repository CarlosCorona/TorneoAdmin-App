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
        public JsonResult ObtenerJornadasVista(int campeonatoID, int categoriaID, int serieID )
        {
            var jornadasLista = from j in _context.Jornadas
                               join p in _context.Partidos on j.PartidoID equals p.ID
                               where j.CampeonatoID == campeonatoID && j.CategoriaID == categoriaID && j.SerieID == serieID
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
        [ValidateAntiForgeryToken]
        public IActionResult CargaInicial([Bind("CampeonatoID, CategoriaID, SerieID, Ronda, Dias, FechaInicial, Hora")]JornadasCarga jornadasCarga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (jornadasCarga.Dias[0] == null)
            {
                return BadRequest("Deben seleccionar al menos un dia a configurar.");
            }

            var juegos = _context.Jornadas.Where(x =>
                                                 x.CampeonatoID == jornadasCarga.CampeonatoID &&
                                                 x.CategoriaID == jornadasCarga.CategoriaID &&
                                                 x.SerieID == jornadasCarga.SerieID &&
                                                 x.Ronda == jornadasCarga.Ronda).ToList();
            if(juegos.Count>0)
                return BadRequest("Ya existe fechas configuradas.");

            try
            {
                // Obtenemos los dias
                int indice = 0;
                int[] dias = new int[jornadasCarga.Dias.Count()];
                foreach (var item in jornadasCarga.Dias)
                {
                    dias[indice] = Convert.ToInt32(item);
                    indice++;
                }

                // Obtenemos los equipos que se han inscripto en el campeonato
                var equipos = (from e in _context.Equipos
                               join i in _context.Inscripciones on e.ID equals i.EquipoID
                               where i.CampeonatoID == jornadasCarga.CampeonatoID &&
                                     e.CategoriaID == jornadasCarga.CategoriaID &&
                                     e.SerieID == jornadasCarga.SerieID
                               select e).OrderBy(x=> x.ID).ToList();

                if (equipos.Count <= 1)
                    return BadRequest("No existen equipos registrados.");

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
                int dia = (int)jornadasCarga.FechaInicial.DayOfWeek;
                if (dias.Contains(dia))
                {
                    fechaInicial = jornadasCarga.FechaInicial.AddHours(jornadasCarga.Hora);
                }
                else {
                    int i = dias.Max();
                    if (dia > i)
                        fechaInicial = jornadasCarga.FechaInicial.AddDays(7 + (dias.Min() - dia)).AddHours(jornadasCarga.Hora);
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
                        fechaInicial = jornadasCarga.FechaInicial.AddDays(i - dia).AddHours(jornadasCarga.Hora);
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
                        Partidos partido = new Partidos
                        {
                            PartidoEstadoID = 1,
                            FechaHora = fechaInicial
                        };
                        _context.Partidos.Add(partido);
                        _context.SaveChanges();

                        //Creamos la jornada y pasamos el id del partido
                        Jornadas jornadas = new Jornadas()
                        {
                            // Le asignamos valores a la jornada
                            CampeonatoID = jornadasCarga.CampeonatoID,
                            PartidoID = partido.ID,
                            EquipoIDLocal = matriz[i],
                            EquipoIDVisita = matriz[j],
                            CategoriaID = jornadasCarga.CategoriaID,
                            SerieID = jornadasCarga.SerieID,
                            GrupoJornada = x,
                            Ronda = jornadasCarga.Ronda
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
                            fechaInicial = fechaInicial.AddDays(dias[0] - dia).AddHours(jornadasCarga.Hora);
                        else
                            fechaInicial = fechaInicial.AddDays(7 + (dias[0] - dia)).AddHours(jornadasCarga.Hora);
                    }
                    else
                    {
                        // Si se pasa del elementos del arreglo tomamos el primero
                        if (indexdias > (dias.Length - 1))
                            fechaInicial = fechaInicial.AddDays(7 + (dias[0] - dia)).AddHours(jornadasCarga.Hora);
                        else
                        {
                            if (dias[indexdias - 1] == 0)
                                fechaInicial = fechaInicial.AddDays(dias[indexdias] - dia).AddHours(jornadasCarga.Hora);
                            else
                                fechaInicial = fechaInicial.AddDays(7 + (dias[indexdias] - dia)).AddHours(jornadasCarga.Hora);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("CampeonatoID, CategoriaID, SerieID, Ronda, GrupoJornada, EquipoIDLocal, EquipoIDVisita , FechaInicial, Hora")]JornadasCrear jornadasCrear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (jornadasCrear.EquipoIDLocal == jornadasCrear.EquipoIDVisita)
                {
                    return BadRequest("El equipo local y visitante no pueden ser el mismo equipo.");
                }

                if (JornadaExiste(jornadasCrear))
                {
                    return BadRequest("Ya existe esta relación de juego, seleccione otros equipos");
                }

                // Creamos el partido 
                Partidos partido = new Partidos
                {
                    PartidoEstadoID = 1,
                    FechaHora = jornadasCrear.FechaInicial.AddHours(jornadasCrear.Hora)
                };
                _context.Partidos.Add(partido);
                _context.SaveChanges();

                //Creamos la jornada y pasamos el id del partido
                Jornadas jornadas = new Jornadas()
                {
                    // Le asignamos valores a la jornada
                    CampeonatoID = jornadasCrear.CampeonatoID,
                    PartidoID = partido.ID,
                    EquipoIDLocal = jornadasCrear.EquipoIDLocal,
                    EquipoIDVisita = jornadasCrear.EquipoIDVisita,
                    CategoriaID = jornadasCrear.CategoriaID,
                    SerieID = jornadasCrear.SerieID,
                    GrupoJornada = jornadasCrear.GrupoJornada,
                    Ronda = jornadasCrear.Ronda
                };

                _context.Jornadas.Add(jornadas);
                await _context.SaveChangesAsync();
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

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar([Bind("ID, Grupo, Fecha, Hora")]JornadaEditar jornadaEditar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var jornada = _context.Jornadas.Find(jornadaEditar.ID);

                jornada.GrupoJornada = jornadaEditar.Grupo;

                _context.Jornadas.Update(jornada);
                await _context.SaveChangesAsync();

                // TODO:Eliminar todo lo relacionado con partidos previmente.
                var partido = _context.Partidos.Find(jornada.PartidoID);

                partido.FechaHora = jornadaEditar.Fecha.AddHours(jornadaEditar.Hora);

                _context.Partidos.Update(partido);
                await _context.SaveChangesAsync();
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

            return Ok("Registro Actualizado");
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarGrupo([Bind("ID, CampeonatoID, CategoriaID, SerieID, Ronda")]JornadasEliminar jornadasEliminarGrupo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var jornadas = _context.Jornadas.Where(x => x.CampeonatoID == jornadasEliminarGrupo.CampeonatoID &&
                                                           x.CategoriaID == jornadasEliminarGrupo.CategoriaID &&
                                                           x.SerieID == jornadasEliminarGrupo.SerieID &&
                                                           x.Ronda == jornadasEliminarGrupo.Ronda &&
                                                           x.GrupoJornada == jornadasEliminarGrupo.ID);

                // TODO:Eliminar todo lo relacionado con partidos previmente.
                var partidos = from p in _context.Partidos
                               join j in _context.Jornadas on p.ID equals j.PartidoID
                               where j.CampeonatoID == jornadasEliminarGrupo.CampeonatoID &&
                                     j.CategoriaID == jornadasEliminarGrupo.CategoriaID &&
                                     j.SerieID == jornadasEliminarGrupo.SerieID &&
                                     j.Ronda == jornadasEliminarGrupo.Ronda &&
                                     j.GrupoJornada == jornadasEliminarGrupo.ID
                               select p;

                _context.Jornadas.RemoveRange(jornadas);
                await _context.SaveChangesAsync();

                _context.Partidos.RemoveRange(partidos);
                await _context.SaveChangesAsync();
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

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var jornada = _context.Jornadas.Find(id);

                // TODO:Eliminar todo lo relacionado con partidos previmente.
                var partido = _context.Partidos.Find(jornada.PartidoID);

                _context.Jornadas.Remove(jornada);
                await _context.SaveChangesAsync();

                _context.Partidos.Remove(partido);
                await _context.SaveChangesAsync();
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

        [NonAction]
        private bool JornadaExiste(JornadasCrear jornadasCrear)
        {
            return _context.Jornadas.Any(e => e.CampeonatoID == jornadasCrear.CampeonatoID &&
                                              e.CategoriaID == jornadasCrear.CategoriaID &&
                                              e.SerieID == jornadasCrear.SerieID &&
                                              e.Ronda == jornadasCrear.Ronda &&
                                              e.GrupoJornada == jornadasCrear.GrupoJornada &&
                                              e.EquipoIDLocal == jornadasCrear.EquipoIDLocal &&
                                              e.EquipoIDVisita == jornadasCrear.EquipoIDVisita);
        }
    }
}