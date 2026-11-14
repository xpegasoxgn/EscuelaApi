using EscuelaApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Infraestructura.Conexiones
{
    /// <summary>
    /// Contexto principal de Entity Framework Core para la base de datos EscuelaCursoBD.
    /// Administra las conexiones, mapeos de entidades y operaciones CRUD sobre la BD.
    /// </summary>
    public class EscuelaDbContext : DbContext
    {
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options)
        {
        }

        // DbSets que representan las tablas consultables y persistibles en SQL Server
        public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
        public DbSet<Profesor> Profesores => Set<Profesor>();
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Inscripcion> Inscripciones => Set<Inscripcion>();

        /// <summary>
        /// Configura el mapeo explícito (Fluent API) entre las clases C# y las tablas en SQL Server.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo de la tabla dbo.Estudiante
            modelBuilder.Entity<Estudiante>().ToTable("Estudiante", "dbo");
            modelBuilder.Entity<Estudiante>().HasKey(e => e.IdEstudiante);

            // Mapeo de la tabla dbo.Profesor
            modelBuilder.Entity<Profesor>().ToTable("Profesor", "dbo");
            modelBuilder.Entity<Profesor>().HasKey(e => e.IdProfesor);

            // Mapeo de la tabla dbo.Curso
            modelBuilder.Entity<Curso>().ToTable("Curso", "dbo");
            modelBuilder.Entity<Curso>().HasKey(e => e.IdCurso);

            // Mapeo de la tabla dbo.Inscripcion
            modelBuilder.Entity<Inscripcion>().ToTable("Inscripcion", "dbo");
            modelBuilder.Entity<Inscripcion>().HasKey(e => e.IdInscripcion);
        }
    }
}
