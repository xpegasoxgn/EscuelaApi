using EscuelaApi.Servicios;
using EscuelaAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EscuelaApi.Controllers
{
    [ApiController]
    [Route("api/profesores")]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesoresController(IProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        /// <summary>
        /// GET: api/profesores
        /// Obtiene la lista completa de profesores a través de la capa de servicio.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var profesores = await _profesorService.ListarAsync();
            return Ok(profesores);
        }

        /// <summary>
        /// POST: api/profesores
        /// Crea un nuevo profesor en el sistema delegando la persistencia al servicio.
        /// Retorna 201 Created con los datos del profesor recién insertado.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProfesorDTO solicitud)
        {
            var profesor = await _profesorService.CrearAsync(solicitud.Nombre);
            return StatusCode(StatusCodes.Status201Created, profesor);
        }
    }
}
