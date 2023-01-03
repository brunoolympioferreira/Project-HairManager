using FluentAssertions;
using HairManager.Comunication.Requests;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.Test.V1.Usuario.Login;
public class LoginTest : ControllerBase
{
    private const string METODO = "api/login";

    private HairManager.Domain.Entities.Usuario _usuario;
    private string _senha;
    public LoginTest(HairManagerApplicationFactory<Program> factory) : base(factory)
    {
        _usuario = factory.RecuperarUsuario();
        _senha = factory.RecuperarSenha();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        RequestLoginDTO request = new()
        {
            Email = _usuario.Email,
            Senha = _senha
        };

        HttpResponseMessage response = await PostRequest(METODO, request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await using Stream responseBody = await response.Content.ReadAsStreamAsync();

        JsonDocument responseData = await JsonDocument.ParseAsync(responseBody);

        responseData.RootElement.GetProperty("nome").GetString().Should().NotBeNullOrWhiteSpace().And.Be(_usuario.Nome);
        responseData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();

    }
}

