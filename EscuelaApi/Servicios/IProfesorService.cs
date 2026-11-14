using EscuelaApi.Entidades;

namespace EscuelaApi.Servicios
{
    /// <summary>
    /// Contrato para las operaciones de negocio y persistencia de Profesores.
    /// </summary>
    public interface IProfesorService
    {
        /// <summary>
        /// Obtiene la lista completa de profesores ordenados por su ID.
        /// </summary>
        Task<List<Profesor>> ListarAsync();

        /// <summary>
        /// Registra un nuevo profesor en el sistema y retorna la entidad con el ID asignado.
        /// </summary>
        /// <param name="nombre">Nombre del profesor.</param>
        Task<Profesor> CrearAsync(string nombre);
    }
}
