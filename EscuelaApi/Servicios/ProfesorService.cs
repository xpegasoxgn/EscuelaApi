using EscuelaApi.Entidades;
using EscuelaApi.Infraestructura.Conexiones;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Servicios
{
    /// <summary>
    /// Implementación de la lógica de negocio para la gestión de Profesores.
    /// Separa las consultas de base de datos del controlador.
    /// </summary>
    public class ProfesorService : IProfesorService
    {
        private readonly EscuelaDbContext _db;

        public ProfesorService(EscuelaDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Consulta todos los profesores sin seguimiento de cambios (AsNoTracking) para optimizar lectura.
        /// </summary>
        public Task<List<Profesor>> ListarAsync()
        {
            return _db.Profesores
                .AsNoTracking()
                .OrderBy(p => p.IdProfesor)
                .ToListAsync();
        }

        /// <summary>
        /// Prepara y persiste un nuevo profesor en SQL Server, retornando el registro con su IdProfesor generado.
        /// </summary>
        public async Task<Profesor> CrearAsync(string nombre)
        {
            var profesor = new Profesor
            {
                Nombre = nombre.Trim()
            };

            _db.Profesores.Add(profesor);
            await _db.SaveChangesAsync();

            return profesor;
        }
    }
}
