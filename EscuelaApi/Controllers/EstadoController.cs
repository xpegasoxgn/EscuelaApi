using Microsoft.AspNetCore.Mvc;

namespace EscuelaApi.Controllers;

[ApiController]
[Route("api/estado")]
public class EstadoController : ControllerBase
{
    [HttpGet]
    public IActionResult Obtener()
    {
        return Ok(new
        {
            mensaje = "EscuelaApi está funcionando"
        });
    }
}