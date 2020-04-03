using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TorneosAdmin.Web.Models
{
    public class Equipos
    {
        [Column("EquipoID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        public int? LigaID { get; set; }

        public int? DirigenteID { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese el apellidp.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha inicio de fundación.")]
        public DateTime FechaFundacion { get; set; }

        [Required(ErrorMessage = "Ingrese la dirección.")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "Ingrese el estado del equipo.")]
        public string Estado { get; set; }

        public byte[] Foto { get; set; }

        [NotMapped]
        public string NombreArchivo { get; set; }
    }
}
