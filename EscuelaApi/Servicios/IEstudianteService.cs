namespace EscuelaApi.Servicios
{
    public interface IEstudianteService
    {
        Task<ResultadoEliminarEstudiante> EliminarAsync(int id);
    }

    /* Estados para saber qué código HTTP responder en el controlador */
    public enum ResultadoEliminarEstudiante
    {
        Eliminado,          // 204 NoContent
        NoEncontrado,       // 404 NotFound
        TieneInscripciones  // 400 BadRequest (regla de negocio: no borrar si tiene materias)
    }
}
