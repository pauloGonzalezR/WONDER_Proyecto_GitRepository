using Microsoft.EntityFrameworkCore;

namespace WONDER_Proyecto.Models
{
    public class WONDER_ProyectoContext:DbContext
    {
        public WONDER_ProyectoContext(DbContextOptions<WONDER_ProyectoContext> options)
        : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
    }
}
