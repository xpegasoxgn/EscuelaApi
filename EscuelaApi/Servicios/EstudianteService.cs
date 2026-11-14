using EscuelaApi.Infraestructura.Conexiones;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Servicios
{
    /// <summary>
    /// Implementación de la lógica de negocio para la gestión de Estudiantes.
    /// Encapsula las reglas de validación y acceso a datos mediante EF Core.
    /// </summary>
    public class EstudianteService : IEstudianteService
    {
        private readonly EscuelaDbContext _db;

        public EstudianteService(EscuelaDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Aplica la regla de negocio: "Un estudiante solo puede eliminarse si no tiene inscripciones activas".
        /// </summary>
        public async Task<ResultadoEliminarEstudiante> EliminarAsync(int id)
        {
            // Paso 1: Verificar si el estudiante existe en la base de datos
            var estudiante = await _db.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return ResultadoEliminarEstudiante.NoEncontrado;
            }

            // Paso 2: Validar si el estudiante tiene al menos una inscripción registrada
            bool tieneInscripcion = await _db.Inscripciones.AnyAsync(i => i.IdEstudiante == id);
            if (tieneInscripcion)
            {
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }

            // Paso 3: Proceder a eliminar de la tabla y confirmar los cambios en la BD
            try
            {
                _db.Estudiantes.Remove(estudiante);
                await _db.SaveChangesAsync();
                return ResultadoEliminarEstudiante.Eliminado;
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 547)
            {
                // Error 547 en SQL Server: Violación de restricción de clave foránea (FK_Inscripcion_Estudiante)
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }
        }
    }
}
