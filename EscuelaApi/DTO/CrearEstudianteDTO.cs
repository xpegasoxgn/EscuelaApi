using System.ComponentModel.DataAnnotations;

namespace EscuelaAPI.DTO
{
    /// <summary>
    /// Objeto de Transferencia de Datos (DTO) para la creación y actualización de Estudiantes.
    /// Define las reglas de validación de entrada para las peticiones HTTP (POST y PUT).
    /// </summary>
    public class CrearEstudianteDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}
