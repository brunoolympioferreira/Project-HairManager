using HairManager.Application.Services.Usuario.Login;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairManager.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : HairManagerController
{
    /// <summary>
    /// Login Usuario com email e senha
    /// </summary>
    /// <returns>Login</returns>
    /// <response code="200">
    ///     Retorna Token apos Login Usuario
    ///  {
    ///     "email": "usertest@email.com",
    ///     "senha": "123456"
    ///  }
    /// </response>
    [HttpPost]
    [ProducesResponseType(typeof(ResponseLoginDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login(
        [FromServices] ILoginService service,
        [FromBody] RequestLoginDTO request)
    {
        var response = await service.Executar(request);

        return Ok(response);
    }
}
