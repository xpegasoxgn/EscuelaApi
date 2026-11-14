using EscuelaApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
namespace EscuelaApi.Infraestructura.Conexiones
{
    public class EscuelaDbContext: DbContext
    {
        //asp.net nos entrega las opciones que registramos en program.cs
        // base:option pasa esa configuracion al dbcontext en EF core
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options)
        {
        }
        //para consultar estudaintes por ejemplo : _db.Estudiantes.TolistAsync();
        // declara la propiedad no ejecuta ninguna consulta.
        public DbSet<Estudiante> Estudiantes { get; set; }

        //aqui configuramos como se relaciona la clase c# con la tabla sql
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>().ToTable("Estudiante", "dbo");
            modelBuilder.Entity<Estudiante>().HasKey(e => e.IdEstudiante);
        }
    }
}
