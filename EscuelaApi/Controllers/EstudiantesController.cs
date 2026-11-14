using EscuelaApi.Entidades;
using EscuelaApi.Infraestructura.Conexiones;
using EscuelaApi.Servicios;
using EscuelaAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Controllers
{
    [ApiController]
    [Route("api/estudiantes")]
    public class EstudiantesController : ControllerBase
    {
        private readonly EscuelaDbContext _context;
        private readonly IEstudianteService _estudianteService;

        public EstudiantesController(EscuelaDbContext context, IEstudianteService estudianteService)
        {
            _context = context;
            _estudianteService = estudianteService;
        }

        // GET: api/estudiantes
        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> Listar()
        {
            var estudiantes = await _context.Estudiantes
                .AsNoTracking()
                .OrderBy(e => e.IdEstudiante)
                .ToListAsync();

            return Ok(estudiantes);
        }

        // GET: api/estudiantes/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Estudiante>> ObtenerPorId(int id)
        {
            var estudiante = await _context.Estudiantes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdEstudiante == id);

            if (estudiante == null)
            {
                return NotFound(new { mensaje = $"No existe un estudiante con ID {id}, favor de revisar." });
            }

            return Ok(estudiante);
        }

        // POST: api/estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiante>> Crear([FromBody] CrearEstudianteDTO solicitud)
        {
            var estudiante = new Estudiante { Nombre = solicitud.Nombre.Trim() };
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = estudiante.IdEstudiante }, estudiante);
        }

        // PUT: api/estudiantes/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Actualizar(int id, [FromBody] CrearEstudianteDTO solicitud)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound(new { mensaje = $"No existe un estudiante con ID {id}. Favor de revisar." });
            }

            estudiante.Nombre = solicitud.Nombre.Trim();
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = estudiante.IdEstudiante }, estudiante);
        }

        // DELETE: api/estudiantes/1 (aplica regla de inscripciones via servicio)
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var resultado = await _estudianteService.EliminarAsync(id);

            return resultado switch
            {
                ResultadoEliminarEstudiante.Eliminado => NoContent(),
                ResultadoEliminarEstudiante.NoEncontrado => NotFound(new { mensaje = $"No existe un estudiante con ID {id}. Favor de revisar." }),
                ResultadoEliminarEstudiante.TieneInscripciones => BadRequest(new { mensaje = $"El estudiante con ID {id} tiene inscripciones y no puede ser eliminado." }),
                _ => StatusCode(500, new { mensaje = "Ocurrió un error inesperado." })
            };
        }
    }
}
