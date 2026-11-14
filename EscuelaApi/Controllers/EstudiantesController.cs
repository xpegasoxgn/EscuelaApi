using EscuelaApi.Entidades;
using EscuelaApi.Infraestructura.Conexiones;
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

        public EstudiantesController(EscuelaDbContext context)
        {
            _context = context;
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
            var estudiantes = await _context.Estudiantes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdEstudiante == id);
            if (estudiantes == null)
            {
                return NotFound(new { mensaje = $"No existe un estudiante con ID {id}, favor de revisar." });
            }
            return Ok(estudiantes);
        }

        // POST: api/estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiante>> Crear(
            [FromBody] CrearEstudianteDTO solicitud)
        {
            var estudiante = new Estudiante { Nombre = solicitud.Nombre.Trim() };
            //EF core prepara el registro nuevo
            _context.Estudiantes.Add(estudiante);

            await _context.SaveChangesAsync();
            //respondemos 201 y damos la ruta para consultar el alumno

            return CreatedAtAction(nameof(ObtenerPorId), new { id = estudiante.IdEstudiante }, estudiante);
        }
    }
}
