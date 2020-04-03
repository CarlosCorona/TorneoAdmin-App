﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorneosAdmin.Web.Extensiones;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers
{
    public class ProfesionesController : Controller
    {
        private readonly ModelEntities _context;
        public ProfesionesController(ModelEntities context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult ObtenerProfesiones(string si1dx, string sort, int page, int rows)
        {
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var profesinesLista = _context.Profesiones.Select(x => new {
                x.ID,
                x.Descripcion
            });
            int totalRecords = profesinesLista.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                profesinesLista = profesinesLista.OrderByDescending(t => t.Descripcion);
                profesinesLista = profesinesLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                profesinesLista = profesinesLista.OrderBy(t => t.Descripcion);
                profesinesLista = profesinesLista.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = profesinesLista
            };
            return Json(jsonData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("Descripcion")] Profesiones profesiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                profesiones.Descripcion = profesiones.Descripcion.Trim();
                _context.Profesiones.Add(profesiones);
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

            return Ok(profesiones);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Descripcion")] Profesiones profesiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Profesiones entidad = _context.Profesiones.Find(id);

                entidad.Descripcion = profesiones.Descripcion.Trim();

                _context.Profesiones.Update(entidad);
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

            return Ok(profesiones);
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
                Profesiones entidad = _context.Profesiones.Find(id);

                _context.Profesiones.Remove(entidad);
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