using FluentAssertions;
using HairManager.Application.Services.Usuario.AlterarSenha;
using HairManager.Exceptions.ExceptionsBase;
using UtilsForTests.Requests;
using Xunit;

namespace Validators.Test.Usuario.AlterarSenha;
public class AlterarSenhaValidatorTest
{
    [Fact]
    public void Validar_Sucesso()
    {
        var validator = new AlterarSenhaValidator();

        var request = RequestAlterarSenhaUsuarioBuilder.Construir();
        request.ConfirmeNovaSenha = request.NovaSenha;

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Validar_Erro_Tamanho_Senha_Invalida(int tamanhoSenha)
    {
        var validator = new AlterarSenhaValidator();

        var request = RequestAlterarSenhaUsuarioBuilder.Construir(tamanhoSenha);
        request.ConfirmeNovaSenha = request.NovaSenha;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.
            Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES));
        
    }

    [Fact]
    public void Validar_Erro_Senha_Vazio()
    {
        var validator = new AlterarSenhaValidator();

        var request = RequestAlterarSenhaUsuarioBuilder.Construir();
        request.ConfirmeNovaSenha = request.NovaSenha;
        request.NovaSenha = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO));
    }
}
