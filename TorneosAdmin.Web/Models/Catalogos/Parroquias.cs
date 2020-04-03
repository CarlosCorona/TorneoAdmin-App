using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TorneosAdmin.Web.Models
{
    public class Parroquias
    {
        [Column("ParroquiaID"), ScaffoldColumn(false)]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar un provincia")]
        public int ProvinciaID { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string Nombre { get; set; }
    }
}
