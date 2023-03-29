using HairManager.Api.Filtros;
using HairManager.Application.Services.Funcionario;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HairManager.Api.Controllers;

[ServiceFilter(typeof(UsuarioAutenticadoAttribute))]
[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : HairManagerController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseBaseDTO), StatusCodes.Status201Created)]
    public async Task<IActionResult> Adicionar(
        [FromServices] IAdicionarFuncionarioService service,
        [FromBody] RequestAdicionarFuncionarioDTO request)
    {
        var response = await service.Executar(request);

        return Created(string.Empty, response);
    }
}
