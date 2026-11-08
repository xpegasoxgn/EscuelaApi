using EscuelaApi.Entidades;
using EscuelaApi.Infrastructura.Conexiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EscuelaApi.Dtos;
using EscuelaApi.Servicios;
namespace EscuelaApi.Controllers
{
    [ApiController]
    [Route("api/estudiantes")]
    public class EstudiantesController: ControllerBase
    {
        private readonly EscuelaDbContext _context;
        private readonly IEstudianteService _estudianteService;

        public EstudiantesController(EscuelaDbContext context, IEstudianteService estudianteService)
        {
            _context = context;
            _estudianteService = estudianteService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Estudiantes>>> listar()
        {
            var estudiantes = await _context.Estudiantes.AsNoTracking().OrderBy(e=> e.IdEstudiante).ToListAsync();
            return Ok(estudiantes);

            
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<Estudiantes>>> obtenerPorId(int id)
        {
            var estudiantes = await _context.Estudiantes.AsNoTracking().FirstOrDefaultAsync(e => e.IdEstudiante == id);
            if(estudiantes is null)
            {
                return NotFound(new { mensaje = $"No existe un estudiante con ID  {id}. favor de revisar" });
            }

            return Ok(estudiantes);


        }

        [HttpPost]
        public async Task<ActionResult<Estudiantes>> Crear(
            [FromBody] CrearEstudiantesDto solicitud)
        {
            var estudiante = new Estudiantes { Nombre = solicitud.Nombre.Trim() };
            //EF core prepara el registro nuevo
            _context.Estudiantes.Add(estudiante);

            await _context.SaveChangesAsync();
            //respondemos 201 y damos la ruta para consultar el alumno

            return CreatedAtAction(nameof(obtenerPorId), new { id= estudiante.IdEstudiante},estudiante);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Actualizar(int id, [FromBody] CrearEstudiantesDto solicitud)
        {
            //mediante el id obtenemos el registro de la base de datos
            var estudiante = await _context.Estudiantes.FindAsync(id);
            // validacion para verificar si el registro existe, si no existe devolvemos un 404
            if (estudiante == null)
            {
                return NotFound(new { mensaje = $"No existe un estudiante con ID {id}. favor de revisar" });
            }
            //cambiamos el nombre del regitro existente, no su id
            estudiante.Nombre = solicitud.Nombre.Trim();
            // EF core prepara la actualizacion del registro
            await _context.SaveChangesAsync();



            return CreatedAtAction(nameof(obtenerPorId), new { id = estudiante.IdEstudiante }, estudiante);
        }

        //podemos borrar a un estudiante  de pruebe que no tenga inscripciones pero no uno que ya este incrito en una materia
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var resultado = await _estudianteService.EliminarAsync(id);

            return resultado switch
            {
                ResultadoEliminarEstudiante.Eliminado => NoContent(),
                ResultadoEliminarEstudiante.NoEncontrado => NotFound(new { mensaje = $"No existe un estudiante con ID {id}. favor de revisar" }),
                ResultadoEliminarEstudiante.TieneInscripciones => BadRequest(new { mensaje = $"El estudiante con ID {id} tiene inscripciones y no puede ser eliminado." }),
                _ => StatusCode(500, new { mensaje = "Ocurrió un error inesperado." })
            };
        }
    }
}
