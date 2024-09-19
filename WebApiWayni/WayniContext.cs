using Microsoft.EntityFrameworkCore;
using WebApiWayni.Models;

namespace WebApiWayni
{
    public class WayniContext:DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        public WayniContext(DbContextOptions<WayniContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.ToTable("Usuario");
                usuario.HasKey(p => p.Id);
                usuario.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
                usuario.Property(p => p.Apellido).IsRequired().HasMaxLength(200);
                usuario.Property(p => p.DNI).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
