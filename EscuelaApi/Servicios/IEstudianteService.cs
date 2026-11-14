namespace EscuelaApi.Servicios
{
    /// <summary>
    /// Contrato para las operaciones de lógica de negocio relacionadas con Estudiantes.
    /// </summary>
    public interface IEstudianteService
    {
        /// <summary>
        /// Elimina un estudiante por su ID aplicando la regla de negocio de inscripciones.
        /// </summary>
        /// <param name="id">Identificador del estudiante.</param>
        /// <returns>Resultado del intento de eliminación (Eliminado, NoEncontrado o TieneInscripciones).</returns>
        Task<ResultadoEliminarEstudiante> EliminarAsync(int id);
    }

    /// <summary>
    /// Estados posibles que describe el resultado de la operación de eliminación de un estudiante.
    /// Permite al controlador traducir el resultado de negocio a códigos de estado HTTP (204, 404, 400).
    /// </summary>
    public enum ResultadoEliminarEstudiante
    {
        /// <summary>El estudiante existía, no tenía cursos inscritos y fue eliminado correctamente (HTTP 204).</summary>
        Eliminado,

        /// <summary>No se encontró un estudiante con el ID especificado en la base de datos (HTTP 404).</summary>
        NoEncontrado,

        /// <summary>El estudiante tiene materias inscritas activas y la regla prohíbe eliminarlo (HTTP 400).</summary>
        TieneInscripciones
    }
}
