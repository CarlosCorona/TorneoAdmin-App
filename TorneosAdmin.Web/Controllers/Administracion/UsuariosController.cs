using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ModelEntities _context;

        public UsuariosController(ModelEntities context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult ObtenerUsuarios(string si1dx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            // Nunca sera mostrado el usuario administrador para su edición
            var rolesLista = _context.Usuarios.Where(x => x.ID != 1).Select(x => new {
                x.ID,
                x.Usuario,
                x.Nombre,
                x.ApellidoPaterno,
                x.ApellidoMaterno,
                x.CorreoElectronico,
                x.Telefono,
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
                rolesLista = rolesLista.OrderBy(t => t.ID);
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
        public async Task<IActionResult> Editar(int id, [Bind("Usuario, Nombre, ApellidoPaterno, ApellidoMaterno, CorreoElectronico, Telefono, Eliminado")] Usuarios usuarios)
        {
            if (id != usuarios.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Usuarios entidad = _context.Usuarios.Find(id);

                    entidad.Nombre = usuarios.Nombre;
                    entidad.ApellidoPaterno = usuarios.ApellidoPaterno;
                    entidad.ApellidoMaterno = usuarios.ApellidoMaterno;
                    entidad.CorreoElectronico = usuarios.CorreoElectronico;
                    entidad.Telefono = usuarios.Telefono;

                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!UsuarioExiste(usuarios.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            return View("Usurios", usuarios);
        }

        [NonAction]
        private bool UsuarioExiste(int id)
        {
            return _context.Usuarios.Any(e => e.ID == id);
        }
    }
}