using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorneosAdmin.Web.Extensiones;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers
{
    public class EquiposController : Controller
    {
        private readonly ModelEntities _context;

        public EquiposController(ModelEntities context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult ObtenerEquipos(string si1dx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var equiposdirigentesLista = _context.Equipos.Select(x => new {
                x.ID,
                x.LigaID,
                x.DirigenteID,
                x.Nombre,
                x.Color,
                x.FechaFundacion,
                x.Serie,
                x.Estado,
                x.Foto
            });
            int totalRecords = equiposdirigentesLista.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sort.ToUpper() == "DESC")
            {
                equiposdirigentesLista = equiposdirigentesLista.OrderByDescending(t => t.Nombre);
                equiposdirigentesLista = equiposdirigentesLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                equiposdirigentesLista = equiposdirigentesLista.OrderBy(t => t.Nombre);
                equiposdirigentesLista = equiposdirigentesLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = equiposdirigentesLista
            };
            return Json(jsonData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("LigaID, DirigenteID, Nombre, Color, FechaFundacion, Serie, Estado, NombreArchivo")] Equipos equipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\TempFotos"}";

                Equipos entidad = new Equipos
                {
                    LigaID = equipos.LigaID == 0 ? null : equipos.LigaID,
                    DirigenteID = equipos.DirigenteID == 0 ? null : equipos.DirigenteID,
                    Nombre = equipos.Nombre,
                    Color = equipos.Color,
                    FechaFundacion = equipos.FechaFundacion,
                    Serie = equipos.Serie,
                    Estado = equipos.Estado,
                    Foto = string.IsNullOrWhiteSpace(equipos.NombreArchivo) == false ? FormateadorImagen.CambiarTamanio(path + "\\" + equipos.NombreArchivo, 600, 400) : null
                };

                _context.Equipos.Add(entidad);
                await _context.SaveChangesAsync();

                // Al final de la modificación eliminamos el archivo
                if (!string.IsNullOrWhiteSpace(equipos.NombreArchivo))
                    System.IO.File.Delete(path + "\\" + equipos.NombreArchivo);
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

            return Ok(equipos);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("LigaID, DirigenteID, Nombre, Color, FechaFundacion, Serie, Estado, NombreArchivo")] Equipos equipos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\TempFotos"}";

                Equipos entidad = _context.Equipos.Find(id);

                entidad.LigaID = equipos.LigaID == 0 ? null : equipos.LigaID;
                entidad.DirigenteID = equipos.DirigenteID == 0 ? null : equipos.DirigenteID;
                entidad.Nombre = equipos.Nombre;
                entidad.Color = equipos.Color;
                entidad.FechaFundacion = equipos.FechaFundacion;
                entidad.Serie = equipos.Serie;
                entidad.Estado = equipos.Estado;

                if (!string.IsNullOrWhiteSpace(equipos.NombreArchivo))
                {
                    if (System.IO.File.Exists(path + "\\" + equipos.NombreArchivo))
                    {
                        entidad.Foto = FormateadorImagen.CambiarTamanio(path + "\\" + equipos.NombreArchivo, 600, 400);
                    }
                }

                _context.Equipos.Update(entidad);
                await _context.SaveChangesAsync();

                // Al final de la modificación eliminamos el archivo
                if (!string.IsNullOrWhiteSpace(equipos.NombreArchivo))
                    System.IO.File.Delete(path + "\\" + equipos.NombreArchivo);
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

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                Equipos entidad = _context.Equipos.Find(id);

                _context.Equipos.Remove(entidad);
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

        [HttpPost]
        public async Task<IActionResult> SubirFoto(IFormFile archivo)
        {
            string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\TempFotos"}";
            string nombre = DateTime.Now.ToString("HH.mm.ss.ffff.") + archivo.FileName;
            path = path + "\\" + nombre;

            if (archivo.Length > 0)
            {
                using (var stream = System.IO.File.Create(path))
                {
                    await archivo.CopyToAsync(stream);
                }
            }
            return Ok(new { foto = nombre });
        }

        [HttpPost]
        public IActionResult ElimintarFoto(string archivo)
        {
            string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\TempFotos"}";
            if (System.IO.File.Exists(path + "\\" + archivo))
            {
                System.IO.File.Delete(path + "\\" + archivo);
            }
            return Ok();
        }
    }
}