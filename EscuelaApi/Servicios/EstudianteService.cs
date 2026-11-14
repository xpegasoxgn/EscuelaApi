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

        public async Task<ResultadoEliminarEstudiante> EliminarAsync(int id)
        {
            var estudiante = await _db.Estudiantes.FindAsync(id);

            // Verificamos si existe el estudiante
            if (estudiante == null)
            {
                return ResultadoEliminarEstudiante.NoEncontrado;
            }

            // Validar si tiene al menos una inscripción pendiente
            bool tieneInscripcion = await _db.Inscripciones.AnyAsync(i => i.IdEstudiante == id);
            if (tieneInscripcion)
            {
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }

            try
            {
                // Propiedad de EF Core para eliminar
                _db.Estudiantes.Remove(estudiante);
                await _db.SaveChangesAsync();
                return ResultadoEliminarEstudiante.Eliminado;
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 547)
            {
                // Error de restricción de clave foránea en SQL Server
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }
        }
    }
}
