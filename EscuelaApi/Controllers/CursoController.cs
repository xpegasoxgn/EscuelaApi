using EscuelaApi.Infraestructura.Conexiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Controllers
{
    [ApiController]
    [Route("api/cursos")]
    public class CursoController : ControllerBase
    {
        private readonly EscuelaDbContext _db;

        public CursoController(EscuelaDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// GET: api/cursos
        /// Retorna el listado de todos los cursos disponibles en la escuela ordenados por su ID.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var cursos = await _db.Cursos
                .AsNoTracking()
                .OrderBy(c => c.IdCurso)
                .ToListAsync();

            return Ok(cursos);
        }
    }
}
