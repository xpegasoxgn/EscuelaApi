using EscuelaApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Infraestructura.Conexiones
{
    public class EscuelaDbContext : DbContext
    {
        // asp.net nos entrega las opciones que registramos en program.cs
        // base:options pasa esa configuracion al dbcontext en EF core
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options)
        {
        }

        // Para consultar estudiantes por ejemplo: _db.Estudiantes.ToListAsync()
        public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
        public DbSet<Profesor> Profesores => Set<Profesor>();
        public DbSet<Curso> Cursos => Set<Curso>();
        public DbSet<Inscripcion> Inscripciones => Set<Inscripcion>();

        // Aqui configuramos como se relaciona la clase c# con la tabla sql
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
