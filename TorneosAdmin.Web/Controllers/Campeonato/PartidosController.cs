using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorneosAdmin.Web.Extensiones;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers.Campeonato
{
    public class PartidosController : Controller
    {
        private readonly ModelEntities _context;

        public PartidosController(ModelEntities context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult ObtenerPartidos(string si1dx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var partidosLista = _context.Partidos.Select(x => new
            {
                x.ID,
                x.PartidoEstadoID,
                x.ArbitroIDCentral,
                x.ArbitroIDLateraDerecho,
                x.ArbitroIDLateralIzquierdo,
                x.VocalEquipoLocal,
                x.VocalEquipoVisitante
            });
            int totalRecords = partidosLista.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sort.ToUpper() == "DESC")
            {
                partidosLista = partidosLista.OrderByDescending(t => t.ID);
                partidosLista = partidosLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                partidosLista = partidosLista.OrderBy(t => t.ID);
                partidosLista = partidosLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = partidosLista
            };
            return Json(jsonData);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("ArbitroIDCentral, ArbitroIDLateraDerecho, ArbitroIDLateralIzquierdo, VocalEquipoLocal, VocalEquipoVisitante")] Partidos partidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Partidos entidad = _context.Partidos.Find(id);

                if (entidad.PartidoEstadoID != 1)
                {
                    return BadRequest("Partido no se puede configurar debia que ya fue jugado.");
                }

                entidad.ArbitroIDCentral = partidos.ArbitroIDCentral;
                entidad.ArbitroIDLateraDerecho = partidos.ArbitroIDLateraDerecho;
                entidad.ArbitroIDLateralIzquierdo = partidos.ArbitroIDLateralIzquierdo;
                entidad.VocalEquipoLocal = partidos.VocalEquipoLocal;
                entidad.VocalEquipoVisitante = partidos.VocalEquipoVisitante;


                _context.Partidos.Update(entidad);
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
    }
}