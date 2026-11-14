namespace EscuelaApi.Entidades
{
    // Mapeado a la tabla dbo.Curso
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdProfesor { get; set; } // Referencia a dbo.Profesor
    }
}
