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

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Colegio> Colegios { get; set; } = null!;
        public DbSet<Grupo> Grupos { get; set; } = null!;
        public DbSet<Materia> Materias { get; set; } = null!;
        public DbSet<ProfesorDetalle> ProfesorDetalles { get; set; } = null!;
        public DbSet<AlumnoDetalle> AlumnoDetalles { get; set; } = null!;
        public DbSet<ProfesorGrupoMateria> ProfesorGrupoMaterias { get; set; } = null!;
        public DbSet<Tema> Temas { get; set; } = null!;
        public DbSet<Leccion> Lecciones { get; set; } = null!;
        public DbSet<Pregunta> Preguntas { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<QuizPregunta> QuizPreguntas { get; set; } = null!;
        public DbSet<ResultadoQuiz> ResultadosQuiz { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Enums como string
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
                .HasConversion<string>();

            modelBuilder.Entity<Grupo>()
                .Property(g => g.Turno)
                .HasConversion<string>();

            modelBuilder.Entity<ProfesorDetalle>()
                .Property(p => p.Turno)
                .HasConversion<string>();

            // Clave primaria compuesta para detalles
            modelBuilder.Entity<ProfesorDetalle>()
                .HasKey(p => p.UsuarioId);

            modelBuilder.Entity<AlumnoDetalle>()
                .HasKey(a => a.UsuarioId);

            // Relaciones Usuario–Detalles
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.ProfesorDetalle)
                .WithOne(p => p.Usuario)
                .HasForeignKey<ProfesorDetalle>(p => p.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.AlumnoDetalle)
                .WithOne(a => a.Usuario)
                .HasForeignKey<AlumnoDetalle>(a => a.UsuarioId);

            // Grupo único por Nombre + Turno + Colegio
            modelBuilder.Entity<Grupo>()
                .HasIndex(g => new { g.Nombre, g.Turno, g.ColegioId })
                .IsUnique();
        }
    }
}
