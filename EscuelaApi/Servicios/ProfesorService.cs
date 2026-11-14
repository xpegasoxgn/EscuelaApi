using EscuelaApi.Entidades;
using EscuelaApi.Infraestructura.Conexiones;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Servicios
{
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
            _db.Profesores.Add(profesor);
            await _db.SaveChangesAsync();
            return profesor;
        }
    }
}
