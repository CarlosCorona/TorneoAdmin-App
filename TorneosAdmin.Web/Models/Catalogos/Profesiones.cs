﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneosAdmin.Web.Models
{
    public class Profesiones
    {
        [Column("ProfesionID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripción de la profesión.")]
        public string Descripcion { get; set; }
    }
}
