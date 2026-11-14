namespace EscuelaApi.Servicios
{
    public interface IEstudianteService
    {
        Task<ResultadoEliminarEstudiante> EliminarAsync(int id);
    }

    public enum ResultadoEliminarEstudiante
    {
        Eliminado,
        NoEncontrado,
        TieneInscripciones
    }
}
