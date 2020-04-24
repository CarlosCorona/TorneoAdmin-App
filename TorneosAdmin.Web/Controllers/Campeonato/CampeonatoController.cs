﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var lista1 = _context.PartidosEstados.ToDictionary(mc => mc.ID.ToString(), mc => mc.Descripcion, StringComparer.OrdinalIgnoreCase);
            var lista2 = _context.Arbitros.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre + ' ' + mc.Apellido, StringComparer.OrdinalIgnoreCase);
            lista2.Add("0", "Seleccione arbitro");
            ViewBag.PartidosEstadosLista = JsonSerializer.Serialize(lista1);
            ViewBag.ArbitrosLista = JsonSerializer.Serialize(lista2);

            var lista3 = _context.Campeonatos.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista4 = _context.Categorias.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista5 = _context.Series.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista6 = new Dictionary<string, string>();
            lista6.Add("1", "Ronda 1");
            lista6.Add("2", "Ronda 2");
            lista6.Add("3", "Ronda Final");
            var lista7 = _context.Jornadas.Where(x => x.CampeonatoID == Convert.ToInt32(lista3.First().Key) &&
                                                      x.CategoriaID == Convert.ToInt32(lista4.First().Key) &&
                                                      x.SerieID == Convert.ToInt32(lista5.First().Key) &&
                                                      x.Ronda == 1)
                                           .Select(x =>new {x.GrupoJornada, Fecha = "Fecha " + x.GrupoJornada.ToString()}).Distinct()
                                           .ToDictionary(mc => mc.GrupoJornada.ToString(), mc => mc.Fecha, StringComparer.OrdinalIgnoreCase);
            ViewBag.CampeonatosLista = lista3;
            ViewBag.CategoriasLista = lista4;
            ViewBag.SeriesLista = lista5;
            ViewBag.RondasLista = lista6;
            ViewBag.FechasLista = lista7;
            return View();
        }
    }
}