using Microsoft.EntityFrameworkCore;

namespace TorneosAdmin.Web.Models
{
    public class ModelEntities : DbContext
    {
        public ModelEntities(){ }

        public ModelEntities(DbContextOptions<ModelEntities> options)
        : base(options)
        { }

        public DbSet<Menus> Menus { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosLogins> UsuariosLogins { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }

    }
}
