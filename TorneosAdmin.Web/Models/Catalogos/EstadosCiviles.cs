using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TorneosAdmin.Web.Models
{
    public class EstadosCiviles
    {
        [Column("EstadoCivilID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripción del estado civil.")]
        public string Descripcion { get; set; }
    }
}
