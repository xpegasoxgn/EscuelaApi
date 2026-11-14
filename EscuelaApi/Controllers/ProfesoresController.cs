using EscuelaApi.Entidades;
using EscuelaApi.Infraestructura.Conexiones;
using EscuelaAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Controllers
{
    [ApiController]
    [Route("api/profesores")]
    public class ProfesoresController : ControllerBase
    {
        private readonly EscuelaDbContext _context;

        public ProfesoresController(EscuelaDbContext context)
        {
            _context = context;
        }

        // GET: api/profesores
        [HttpGet]
        public async Task<ActionResult<List<Profesor>>> Listar()
        {
            var profesores = await _context.Profesores
                .AsNoTracking()
                .OrderBy(p => p.IdProfesor)
                .ToListAsync();

            return Ok(profesores);
        }

        // GET: api/profesores/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profesor>> ObtenerPorId(int id)
        {
            var profesor = await _context.Profesores
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.IdProfesor == id);

            if (profesor == null)
            {
                return NotFound(new { mensaje = $"No existe un profesor con ID {id}, favor de revisar." });
            }

            return Ok(profesor);
        }

        // POST: api/profesores
        [HttpPost]
        public async Task<ActionResult<Profesor>> Crear([FromBody] CrearProfesorDTO solicitud)
        {
            var profesor = new Profesor
            {
                Nombre = solicitud.Nombre.Trim()
            };

            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerPorId), new { id = profesor.IdProfesor }, profesor);
        }
    }
}
