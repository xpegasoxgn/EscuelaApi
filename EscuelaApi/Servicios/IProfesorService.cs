using EscuelaApi.Entidades;

namespace EscuelaApi.Servicios
{
    public interface IProfesorService
    {
        Task<List<Profesor>> ListarAsync();
        Task<Profesor> CrearAsync(string nombre);
    }
}
