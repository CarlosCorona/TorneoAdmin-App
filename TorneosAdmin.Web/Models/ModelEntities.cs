using Microsoft.EntityFrameworkCore;

namespace TorneosAdmin.Web.Models
{
    public class ModelEntities : DbContext
    {
        public ModelEntities(){ }

        public ModelEntities(DbContextOptions<ModelEntities> options)
        : base(options)
        { }

        public DbSet<Campeonatos> Campeonatos { get; set; }
        public DbSet<Dirigentes> Dirigentes { get; set; }
        public DbSet<Equipos> Equipos { get; set; }
        public DbSet<EstadosCiviles> EstadosCiviles { get; set; }
        public DbSet<Instrucciones> Instrucciones { get; set; }
        public DbSet<Jugadores> Jugadores { get; set; }
        public DbSet<Ligas> Ligas { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Parroquias> Parroquias { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Profesiones> Profesiones { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosLogins> UsuariosLogins { get; set; }
        public DbSet<UsuariosRoles> UsuariosRoles { get; set; }

    }
}
