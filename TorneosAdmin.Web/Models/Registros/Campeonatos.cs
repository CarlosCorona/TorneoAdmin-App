using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TorneosAdmin.Web.Models
{
    public class Campeonatos
    {
        [Column("CampeonatoID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha inicio de campeonato.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha fin de campeonato.")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Ingrese el estado del campeonato.")]
        public string Estado { get; set; }

        public bool Eliminado { get; set; }

    }
}
