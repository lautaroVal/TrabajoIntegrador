using Microsoft.EntityFrameworkCore;
using TrabajoIntegrador.Models;

namespace TechServicesApp.DataAccess
{
    public class TechServicesAppDbContext : DbContext
    {

        public TechServicesAppDbContext(DbContextOptions<TechServicesAppDbContext> options) : base(options)
        {
        }

        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }

    
}
