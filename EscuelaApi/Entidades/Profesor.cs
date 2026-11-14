namespace EscuelaApi.Entidades
{
    /// <summary>
    /// Representa a la entidad Profesor mapeada a la tabla dbo.Profesor en SQL Server.
    /// </summary>
    public class Profesor
    {
        /// <summary>
        /// Identificador único del profesor (Clave primaria autoincremental).
        /// </summary>
        public int IdProfesor { get; set; }

        /// <summary>
        /// Nombre completo del profesor.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
    }
}
