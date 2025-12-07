using EduTechPlus.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EduTechPlus.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Tabla principal
        public DbSet<Usuario> Usuarios { get; set; }

        // Si ya tienes modelos para esto, déjalos:
        public DbSet<Colegio> Colegios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Materia> Materias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índice único por correo
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Correo)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Correo)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.ContrasenaHash)
                .IsRequired();
        }
    }
}