using EscuelaApi.Entidades;
using EscuelaApi.Infrastructura.Conexiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Controllers
{
    [ApiController]
    [Route("api/estudiantes")]
    public class EstudiantesController: ControllerBase
    {
        private readonly EscuelaDbContext _context;

        public EstudiantesController(EscuelaDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Estudiantes>>> listar()
        {
            var estudiantes = await _context.Estudiantes.AsNoTracking().OrderBy(e=> e.IdEstudiante).ToListAsync();
            return Ok(estudiantes);

            
        }


    }
}
