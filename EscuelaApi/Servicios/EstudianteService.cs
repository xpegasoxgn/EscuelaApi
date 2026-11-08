using EscuelaApi.Infrastructura.Conexiones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace EscuelaApi.Servicios
{
    public class EstudianteService:IEstudianteService
    {
        private readonly EscuelaDbContext _db;
        public EstudianteService(EscuelaDbContext db)
        {
            _db = db;
        }
        public async Task<ResultadoEliminarEstudiante> EliminarAsync(int id)
        {
            var estudiante = await _db.Estudiantes.FindAsync(id);
            // select 1 from dbo.estudiantes where id=:id
            //verificamos que exista el estudiante
            if (estudiante == null)
            {
                return ResultadoEliminarEstudiante.NoEncontrado;
            }

            //hay al menos una inscripcion pendiente 
            bool tieneInscripcion = await _db.Inscripciones.AnyAsync(i => i.IdEstudiante == id);
            //select 1 from inscripcion where idEstudiante =:id
            if(tieneInscripcion)
            {
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }
            try
            {
                //propiedad de EF para elimnar
                _db.Estudiantes.Remove(estudiante);
                //EF
                await _db.SaveChangesAsync();
                return ResultadoEliminarEstudiante.Eliminado;
            }
            catch (DbUpdateException ex) when ((ex.InnerException as SqlException)?.Number == 547)
            {
                // Error de restricción de clave foránea, el estudiante tiene inscripciones
                return ResultadoEliminarEstudiante.TieneInscripciones;
            }
        }
    }
}
