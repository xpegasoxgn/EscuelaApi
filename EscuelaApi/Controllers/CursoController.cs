using EscuelaApi.Infrastructura.Conexiones;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EscuelaApi.Controllers
{
    [Route("api/cursos")]
    public class CursoController : ControllerBase
    {
        private readonly EscuelaDbContext _db;
        public CursoController(EscuelaDbContext db  )
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> listar()
        {
            var cursos = await _db.Cursos.AsNoTracking().OrderBy(c => c.IdCurso).ToListAsync();

            return Ok(cursos);
        }
    }
}
