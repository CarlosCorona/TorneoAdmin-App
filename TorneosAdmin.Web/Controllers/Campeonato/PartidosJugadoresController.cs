﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TorneosAdmin.Web.Controllers.Campeonato
{
    public class PartidosJugadoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}