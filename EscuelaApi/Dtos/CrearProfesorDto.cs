using System.ComponentModel.DataAnnotations;

namespace EscuelaApi.Dtos
{
    public class CrearProfesorDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(10, ErrorMessage = "El nombre no puede superar los 10 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}
