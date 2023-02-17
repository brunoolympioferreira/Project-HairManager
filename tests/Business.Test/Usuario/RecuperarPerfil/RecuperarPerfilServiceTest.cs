using AutoMapper;
using FluentAssertions;
using HairManager.Application.Services.Usuario.RecuperarPerfil;
using HairManager.Application.Utils.UsuarioLogado;
using HairManager.Comunication.Responses;
using System.Threading.Tasks;
using UtilsForTests.Entidades;
using UtilsForTests.Mapper;
using UtilsForTests.UsuarioLogado;
using Xunit;

namespace Business.Test.Usuario.RecuperarPerfil;
public class RecuperarPerfilServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        (HairManager.Domain.Entities.Usuario usuario, _) = UsuarioBuilder.Construir();

        RecuperarPerfilService service = CriarUseCase(usuario);

        ResponsePerfilUsuarioDTO response = await service.Executar();

        response.Should().NotBeNull();
        response.Nome.Should().Be(usuario.Nome);
        response.Email.Should().Be(usuario.Email);
        response.Status.Should().Be(usuario.Status);
    }

    private static RecuperarPerfilService CriarUseCase(HairManager.Domain.Entities.Usuario usuario)
    {
        IMapper mapper = MapperBuilder.Instancia();
        IUsuarioLogado usuarioLogado = UsuarioLogadoBuilder.Instancia().RecuperarUsuario(usuario).Construir();

        return new RecuperarPerfilService(mapper, usuarioLogado);
    }
}
