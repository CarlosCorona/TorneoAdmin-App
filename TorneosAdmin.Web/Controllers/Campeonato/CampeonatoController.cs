using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers

{
    public class CampeonatoController : Controller
    {
        private readonly ModelEntities _context;

        public CampeonatoController(ModelEntities context)
        {
            _context = context;
        }

        public IActionResult Inscripciones()
        {
            var lista1 = _context.Campeonatos.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista2 = _context.Equipos.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            //Filtrar por el rol que vaya hacer esta actividad
            var lista3 = _context.Usuarios.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            ViewBag.CampeonatosLista = JsonSerializer.Serialize(lista1);
            ViewBag.EquiposLista = JsonSerializer.Serialize(lista2);
            ViewBag.UsuariosLista = JsonSerializer.Serialize(lista3);
            return View();
        }

        public IActionResult Pases()
        {
            return View();
        }

        public IActionResult Jornadas()
        {
            var lista1 = _context.Campeonatos.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista2 = _context.Categorias.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista3 = _context.Series.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            ViewBag.CampeonatosLista = lista1;
            ViewBag.CategoriasLista = lista2;
            ViewBag.SeriesLista = lista3;

            return View();
        }

        public IActionResult Partidos()
        {
            return View();
        }
    }
}