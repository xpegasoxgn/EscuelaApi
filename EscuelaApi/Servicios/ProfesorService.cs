using EscuelaApi.Entidades;
using EscuelaApi.Infraestructura.Conexiones;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Servicios
{
    // paso 4 definir la service que implementa la interfaz
    public class ProfesorService : IProfesorService
    {
        private readonly EscuelaDbContext _db;

        public ProfesorService(EscuelaDbContext db)
        {
            _db = db;
        }

        public Task<List<Profesor>> ListarAsync()
        {
            return _db.Profesores.AsNoTracking().OrderBy(p => p.IdProfesor).ToListAsync();
        }

        public async Task<Profesor> CrearAsync(string nombre)
        {
            var profesor = new Profesor { Nombre = nombre.Trim() };
            _db.Profesores.Add(profesor); // preparamos el registro
            await _db.SaveChangesAsync(); // lo guarda y obtiene el id generado
            return profesor;
        }
    }
}
