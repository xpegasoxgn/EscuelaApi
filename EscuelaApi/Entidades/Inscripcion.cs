namespace EscuelaApi.Entidades;

public class Inscripcion
{
    public int IdInscripcion { get; set; }
    public int IdEstudiante { get; set; }
    public int IdCurso { get; set; }
    public DateOnly FechaInscripcion { get; set; }
}