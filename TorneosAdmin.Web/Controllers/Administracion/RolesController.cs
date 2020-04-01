using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TorneosAdmin.Web.Extensiones;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly ModelEntities _context;

        public RolesController(ModelEntities context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult ObtenerRoles(string si1dx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var rolesLista = _context.Roles.Select(x => new { 
                 x.ID,
                 x.Descripcion,
                 x.Eliminado
            });
            int totalRecords = rolesLista.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                rolesLista = rolesLista.OrderByDescending(t => t.Descripcion);
                rolesLista = rolesLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                rolesLista = rolesLista.OrderBy(t => t.Descripcion);
                rolesLista = rolesLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = rolesLista
            };
            return Json(jsonData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Descripcion,Eliminado")] Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!RolExists(roles.Descripcion.Trim()))
                {
                    roles.Descripcion = roles.Descripcion.Trim();
                    _context.Roles.Add(roles);
                    await _context.SaveChangesAsync();
                }
                else
                    return BadRequest("El rol ya se encuentra registrado, ingrese otra descripción.");
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

            return Ok(roles);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Descripcion,Eliminado")] Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!RolExists(roles.Descripcion.Trim()))
                {
                    Roles entidad = _context.Roles.Find(id);

                    entidad.Descripcion = roles.Descripcion.Trim();

                    _context.Roles.Update(entidad);
                    await _context.SaveChangesAsync();
                }
                else
                    return BadRequest("El rol ya se encuentra registrado, ingrese otra descripción.");
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

            return Ok(roles);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Roles entidad = _context.Roles.Find(id);

                entidad.Eliminado = true;

                _context.Roles.Update(entidad);
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

        [NonAction]
        private bool RolExists(string descripcion)
        {
            return _context.Roles.Any(e => e.Descripcion == descripcion);
        }
    }
}
