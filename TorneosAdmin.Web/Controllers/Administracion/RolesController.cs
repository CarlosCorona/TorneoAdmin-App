using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
                rolesLista = rolesLista.OrderByDescending(t => t.ID);
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
            if (ModelState.IsValid)
            {
                _context.Add(roles);
                await _context.SaveChangesAsync();
                return RedirectToAction("Roles","Administracion");
            }
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Descripcion,Eliminado")] Roles roles)
        {
            if (id != roles.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesExists(roles.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var roles = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(roles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesExists(int id)
        {
            return _context.Roles.Any(e => e.ID == id);
        }
    }
}
