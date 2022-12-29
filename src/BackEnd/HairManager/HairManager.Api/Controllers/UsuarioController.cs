using HairManager.Application.Services.Usuario.Registrar;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HairManager.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : HairManagerController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUsuarioRegistradoDTO), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegistrarUsuario(
        [FromServices] IRegistrarUsuarioService service,
        [FromBody] RequestRegistrarUsuarioDTO request)
    {
        var result = await service.Executar(request);

        return Created(string.Empty, result);
    }
}
