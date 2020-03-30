using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TorneosAdmin.Web.Controllers
{
    public class VocalistasController : Controller
    {
        public IActionResult AsignacionArbitros()
        {
            return View();
        }

        public IActionResult AsignacionVocales()
        {
            return View();
        }

        
    }
}