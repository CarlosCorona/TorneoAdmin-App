using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TorneosAdmin.Web.Models
{
    public class Menus
    {
        [Column("MenusID")]
        public int ID { get; set; }
        
        [Display(Name = "Padre")]
        public int MenusPadre { get; set; }

        public string Titulo { get; set; }

        [Display (Name ="Descripción")]
        public string Descripcion { get; set; }

        public string Ruta { get; set; }

        public string Icono { get; set; }
    }
    public class MenuViewModel
    {
        public string Titulo { get; set; }
        public string Ruta { get; set; }
        public string Icono { get; set; }
        public IList<MenuViewModel> SubMenus { get; set; }
    }
}
