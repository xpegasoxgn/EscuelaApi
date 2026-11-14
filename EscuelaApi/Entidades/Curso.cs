namespace EscuelaApi.Entidades
{
    /// <summary>
    /// Representa a la entidad Curso mapeada a la tabla dbo.Curso en SQL Server.
    /// </summary>
    public class Curso
    {
        /// <summary>
        /// Identificador único del curso (Clave primaria autoincremental).
        /// </summary>
        public int IdCurso { get; set; }

        /// <summary>
        /// Nombre de la materia o curso.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Clave foránea que referencia al profesor asignado (dbo.Profesor).
        /// </summary>
        public int IdProfesor { get; set; }
    }
}
