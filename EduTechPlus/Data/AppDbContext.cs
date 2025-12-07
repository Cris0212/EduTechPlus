using EduTechPlus.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProfesorDetalle> ProfesorDetalles { get; set; }
        public DbSet<AlumnoDetalle> AlumnoDetalles { get; set; }
        public DbSet<Colegio> Colegios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Usuario 1-1 ProfesorDetalle
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.ProfesorDetalle)
                .WithOne(p => p.Usuario)
                .HasForeignKey<ProfesorDetalle>(p => p.UsuarioId);

            // Usuario 1-1 AlumnoDetalle
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.AlumnoDetalle)
                .WithOne(a => a.Usuario)
                .HasForeignKey<AlumnoDetalle>(a => a.UsuarioId);
        }
    }
}
