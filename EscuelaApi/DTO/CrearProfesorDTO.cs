using System.ComponentModel.DataAnnotations;

namespace EscuelaAPI.DTO
{
    /// <summary>
    /// Objeto de Transferencia de Datos (DTO) para la creación de Profesores.
    /// Define las reglas de validación de entrada para el endpoint POST api/profesores.
    /// </summary>
    public class CrearProfesorDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}
