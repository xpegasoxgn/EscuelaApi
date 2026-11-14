using EscuelaApi.Infraestructura.Conexiones;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Servicios
{
    public class EstudianteService : IEstudianteService
    {
        private readonly EscuelaDbContext _db;

        public EstudianteService(EscuelaDbContext db)
        {
            _db = db;
        }

        /* Regla de negocio: no borrar si el estudiante tiene inscripciones */
        public async Task<ResultadoEliminarEstudiante> EliminarAsync(int id)
        {
            // 1. Verificar si existe el estudiante
            var estudiante = await _db.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return ResultadoEliminarEstudiante.NoEncontrado;
            }

            // 2. Validar si tiene inscripciones activas
            bool tieneInscripcion = await _db.Inscripciones.AnyAsync(i => i.IdEstudiante == id);
            if (tieneInscripcion)
            {
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }

            // 3. Si no tiene inscripciones, eliminar
            try
            {
                _db.Estudiantes.Remove(estudiante);
                await _db.SaveChangesAsync();
                return ResultadoEliminarEstudiante.Eliminado;
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 547)
            {
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }
        }
    }
}
