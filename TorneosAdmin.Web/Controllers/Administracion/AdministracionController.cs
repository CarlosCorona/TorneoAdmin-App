﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TorneosAdmin.Web.Controllers
{
    public class AdministracionController : Controller
    {
        public IActionResult Permisos()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult UsuariosRoles()
        {
            return View();
        }
    }
}