using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TorneosAdmin.Web.Models
{
    public class Acceso
    {
        [Required(ErrorMessage = "*"), Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

        public bool Recuerdame { get; set; }
    }
}
