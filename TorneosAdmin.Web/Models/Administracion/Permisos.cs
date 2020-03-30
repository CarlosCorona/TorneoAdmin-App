using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneosAdmin.Web.Models
{
    public class Permisos
    {
        [Column("PermisosID"), ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Name = "Rol")]
        public int RolID { get; set; }

        [Display(Name = "Menu")]
        public int MenuID { get; set; }
    }
}
