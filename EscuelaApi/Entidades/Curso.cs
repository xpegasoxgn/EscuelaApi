namespace EscuelaApi.Entidades
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdProfesor { get; set; }
    }
}
