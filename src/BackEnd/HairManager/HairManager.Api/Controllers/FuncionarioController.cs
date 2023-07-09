using AspNetCore.Hashids.Mvc;
using HairManager.Api.Filtros;
using HairManager.Application.Services.Funcionario.Adicionar;
using HairManager.Application.Services.Funcionario.Listar;
using HairManager.Application.Services.Funcionario.RecuperarPorId;
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
        ResponseBaseDTO response = await service.Executar(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseListarFuncionariosDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarFuncionarios([FromServices] IListarFuncionariosService service)
    {
        return Ok(await service.Executar());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseFuncionarioDetalhesDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> RecuperarPorId(
        [FromServices] IRecuperarFuncionarioPorIdService service, 
        [FromRoute] long id)
    {
        ResponseFuncionarioDetalhesDTO response = await service.Executar(id);
        return Ok(response);
    }
}
