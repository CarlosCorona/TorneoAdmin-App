﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TorneosAdmin.Web.Models
{
    public class Instrucciones
    {
        [Column("InstruccionID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripción de la instrucción.")]
        public string Descripcion { get; set; }
    }
}
