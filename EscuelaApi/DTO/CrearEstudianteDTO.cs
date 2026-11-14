using System.ComponentModel.DataAnnotations;

namespace EscuelaAPI.DTO
{
    public class CrearEstudianteDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}
