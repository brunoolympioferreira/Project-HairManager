using HairManager.Api.Filtros;
using HairManager.Application.Services.Usuario.AlterarSenha;
using HairManager.Application.Services.Usuario.RecuperarPerfil;
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

    [HttpGet]
    [ProducesResponseType(typeof(ResponsePerfilUsuarioDTO), StatusCodes.Status200OK)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute))]
    public async Task<IActionResult> RecuperarPerfil([FromServices] IRecuperarPerfilService service)
    {
        var resultado = await service.Executar();

        return Ok(resultado);
    }

    [HttpPut]
    [Route("alterar-senha")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof(UsuarioAutenticadoAttribute))]
    public async Task<IActionResult> AlterarSenha(
        [FromServices] IAlterarSenhaService service,
        [FromBody] RequestAlterarSenhaDTO request)
    {
        await service.Executar(request);

        return NoContent();
    }
}
