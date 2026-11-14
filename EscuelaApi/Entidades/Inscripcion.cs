namespace EscuelaApi.Entidades
{
    /// <summary>
    /// Representa la relación de inscripción entre un Estudiante y un Curso.
    /// Mapeada a la tabla dbo.Inscripcion en SQL Server.
    /// </summary>
    public class Inscripcion
    {
        /// <summary>
        /// Identificador único de la inscripción (Clave primaria autoincremental).
        /// </summary>
        public int IdInscripcion { get; set; }

        /// <summary>
        /// Clave foránea que referencia al estudiante inscrito (dbo.Estudiante).
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Clave foránea que referencia al curso en el que se inscribe (dbo.Curso).
        /// </summary>
        public int IdCurso { get; set; }

        /// <summary>
        /// Fecha en la que se realizó la inscripción.
        /// </summary>
        public DateOnly FechaInscripcion { get; set; }
    }
}
