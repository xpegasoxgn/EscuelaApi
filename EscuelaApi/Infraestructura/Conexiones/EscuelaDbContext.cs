using EscuelaApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Infraestructura.Conexiones
{
    public class EscuelaDbContext : DbContext
    {
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Profesor> Profesores => Set<Profesor>();
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Inscripcion> Inscripciones => Set<Inscripcion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>().ToTable("Estudiante", "dbo");
            modelBuilder.Entity<Estudiante>().HasKey(e => e.IdEstudiante);

            modelBuilder.Entity<Profesor>().ToTable("Profesor", "dbo");
            modelBuilder.Entity<Profesor>().HasKey(e => e.IdProfesor);

            modelBuilder.Entity<Curso>().ToTable("Curso", "dbo");
            modelBuilder.Entity<Curso>().HasKey(e => e.IdCurso);

            modelBuilder.Entity<Inscripcion>().ToTable("Inscripcion", "dbo");
            modelBuilder.Entity<Inscripcion>().HasKey(e => e.IdInscripcion);
        }
    }
}
