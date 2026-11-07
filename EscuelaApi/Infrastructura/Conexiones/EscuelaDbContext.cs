using EscuelaApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace EscuelaApi.Infrastructura.Conexiones
{
    // db context es la clase base de entity frameworck core.
    // escueladbcontext define que tablas vamos a manejar desde c#
    public class EscuelaDbContext: DbContext
    {

        //asp.net nos entrega las opciones que registramos en program.cs
        // base:option pasa esa configuracion al dbcontext en EF core
        public EscuelaDbContext(DbContextOptions<EscuelaDbContext> options) : base(options)
        {
        }

        //para consultar estudaintes por ejemplo : _db.Estudiantes.TolistAsync();
        // declara la propiedad no ejecuta ninguna consulta.

        public DbSet<Estudiantes> Estudiantes => Set<Estudiantes>();

        //aqui configuramos como se relaciona la clase c# con la tabla sql
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>().ToTable("Estudiante", "dbo");
            modelBuilder.Entity<Estudiantes>().HasKey(e=> e.IdEstudiante);
        }
    }
}
