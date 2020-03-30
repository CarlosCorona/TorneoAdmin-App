using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneosAdmin.Web.Models
{
    public class Roles
    {
        [Column("RolID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Debe ingresar descripción"), Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Esta Deshabilitado?")]
        public bool Eliminado { get; set; }
    }
}
