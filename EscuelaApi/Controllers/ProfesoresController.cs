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

        // GET: api/profesores
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _profesorService.ListarAsync());
        }

        // POST: api/profesores
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProfesorDTO solicitud)
        {
            var profesor = await _profesorService.CrearAsync(solicitud.Nombre.Trim());
            return StatusCode(StatusCodes.Status201Created, profesor);
        }
    }
}
