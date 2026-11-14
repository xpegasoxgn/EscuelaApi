namespace EscuelaApi.Entidades
{
    /// <summary>
    /// Representa a la entidad Estudiante mapeada a la tabla dbo.Estudiante en SQL Server.
    /// </summary>
    public class Estudiante
    {
        /// <summary>
        /// Identificador único del estudiante (Clave primaria autoincremental).
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Nombre completo del estudiante.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
    }
}
