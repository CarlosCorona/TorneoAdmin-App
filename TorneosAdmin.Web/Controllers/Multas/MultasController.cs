﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TorneosAdmin.Web.Controllers
{
    public class MultasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}