using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneosAdmin.Web.Models
{
    public class UsuariosRoles 
    {
        [Column("UsuarioRolID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        [ScaffoldColumn(false), Display(Name = "Usuario")]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "Seleccione un rol."), Display(Name = "Rol")]
        public int RolID { get; set; }
    }
}
