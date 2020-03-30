using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorneosAdmin.Web.Identidad
{
    public class AplicationRole : IdentityRole<int>
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public bool IsDelete { get; set; }

        public AplicationRole() { 
        }

        public AplicationRole(string name) { 
            Name = name; 
        }
    }
}
