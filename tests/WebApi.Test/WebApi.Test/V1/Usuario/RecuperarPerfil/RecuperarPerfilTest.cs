using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.Test.V1.Usuario.RecuperarPerfil;
public class RecuperarPerfilTest : ControllerBase
{
    private const string METODO = "api/usuario";

    private HairManager.Domain.Entities.Usuario _usuario;
    private string _senha;
    public RecuperarPerfilTest(HairManagerApplicationFactory<Program> factory) : base(factory)
    {
        _usuario = factory.RecuperarUsuario();
        _senha = factory.RecuperarSenha();
    }

    [Fact]
    public async Task Validar_Sucesso()
    {
        string token = await Login(_usuario.Email, _senha);

        HttpResponseMessage response = await GetRequest(METODO, token);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        await using Stream responseBody = await response.Content.ReadAsStreamAsync();

        JsonDocument responseData = await JsonDocument.ParseAsync(responseBody);

        responseData.RootElement.GetProperty("nome").GetString().Should().Be(_usuario.Nome);
        responseData.RootElement.GetProperty("email").GetString().Should().Be(_usuario.Email);
        responseData.RootElement.GetProperty("status").GetBoolean().Should().Be(_usuario.Status);
    }
}
