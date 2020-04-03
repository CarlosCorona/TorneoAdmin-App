using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TorneosAdmin.Web.Models;

namespace TorneosAdmin.Web.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly ModelEntities _context;

        public RegistrosController(ModelEntities context)
        {
            _context = context;
        }

        public IActionResult Arbitros()
        {
            return View();
        } 

        public IActionResult Campeonatos()
        {
            return View();
        }

        public IActionResult Dirigentes()
        {
            return View();
        }

        public IActionResult Equipos()
        {
            var lista1 = _context.Ligas.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista2 = _context.Dirigentes.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            lista1.Add("0", "Seleccione Liga");
            lista2.Add("0", "Seleccione Dirigente");
            ViewBag.LigasLista = JsonSerializer.Serialize(lista1);
            ViewBag.DirigentesLista = JsonSerializer.Serialize(lista2);

            return View();
        }

        public IActionResult Inscripciones()
        {
            return View();
        }

        public IActionResult Jugadores()
        {
            var lista1 = _context.Equipos.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista2 = _context.EstadosCiviles.ToDictionary(mc => mc.ID.ToString(), mc => mc.Descripcion, StringComparer.OrdinalIgnoreCase);
            var lista3 = _context.Instrucciones.ToDictionary(mc => mc.ID.ToString(), mc => mc.Descripcion, StringComparer.OrdinalIgnoreCase);
            var lista4 = _context.Profesiones.ToDictionary(mc => mc.ID.ToString(), mc => mc.Descripcion, StringComparer.OrdinalIgnoreCase);
            var lista5 = _context.Provincias.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            var lista6 = _context.Parroquias.ToDictionary(mc => mc.ID.ToString(), mc => mc.Nombre, StringComparer.OrdinalIgnoreCase);
            lista1.Add("0", "Seleccione Equipo");
            ViewBag.EquiposLista = JsonSerializer.Serialize(lista1);
            ViewBag.EstadosCivilesLista = JsonSerializer.Serialize(lista2);
            ViewBag.InstruccionesLista = JsonSerializer.Serialize(lista3);
            ViewBag.ProfesionesLista = JsonSerializer.Serialize(lista4);
            ViewBag.ProvinciasLista = JsonSerializer.Serialize(lista5);
            ViewBag.ParroquiasLista = JsonSerializer.Serialize(lista6);
            return View();
        }

        public IActionResult Ligas()
        {
            return View();
        }

        public IActionResult Pases()
        {
            return View();
        }
    }
}