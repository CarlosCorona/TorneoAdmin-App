using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TorneosAdmin.Web.Controllers
{
    public class RegistrosController : Controller
    {
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

        public IActionResult Inscripciones()
        {
            return View();
        }

        public IActionResult Jugadores()
        {
            return View();
        }

        public IActionResult Pases()
        {
            return View();
        }
    }
}