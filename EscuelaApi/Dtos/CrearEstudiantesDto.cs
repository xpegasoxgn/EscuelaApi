using System.ComponentModel.DataAnnotations;
namespace EscuelaApi.Dtos
{
    public class CrearEstudiantesDto
    {
        [Required(ErrorMessage = "el nombre es obligatorio")]
        [StringLength(10, ErrorMessage = "el nombre no puede superar los 10 caracteres")]
        public string Nombre { get; set; } = string.Empty;

    }
}
