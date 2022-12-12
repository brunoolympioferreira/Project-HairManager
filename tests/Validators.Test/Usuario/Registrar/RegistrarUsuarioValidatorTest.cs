using FluentAssertions;
using HairManager.Application.Services.Usuario.Registrar;
using HairManager.Exceptions.ExceptionsBase;
using UtilsForTests.Requests;
using Xunit;

namespace Validators.Test.Usuario.Registrar;
public class RegistrarUsuarioValidatorTest
{
    [Fact]
    public void Validar_Sucesso()
    {
        var validator = new RegistrarUsuarioValidator();

        var requisicao = RequestRegistrarUsuarioBuilder.Construir();
        requisicao.ConfirmeSenha = requisicao.Senha;

        var result = validator.Validate(requisicao);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validar_Erro_Nome_Vazio()
    {
        var validator = new RegistrarUsuarioValidator();

        var requisicao = RequestRegistrarUsuarioBuilder.Construir();
        requisicao.ConfirmeSenha = requisicao.Senha;
        requisicao.Nome = string.Empty;

        var result = validator.Validate(requisicao);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NOME_USUARIO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Email_Vazio()
    {
        var validator = new RegistrarUsuarioValidator();

        var requisicao = RequestRegistrarUsuarioBuilder.Construir();
        requisicao.ConfirmeSenha = requisicao.Senha;
        requisicao.Email = string.Empty;

        var result = validator.Validate(requisicao);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.EMAIL_USUARIO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Senha_Vazio()
    {
        var validator = new RegistrarUsuarioValidator();

        var requisicao = RequestRegistrarUsuarioBuilder.Construir();
        requisicao.ConfirmeSenha = requisicao.Senha;
        requisicao.Senha = string.Empty;

        var result = validator.Validate(requisicao);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_ConfirmarSenha_Vazio()
    {
        var validator = new RegistrarUsuarioValidator();

        var requisicao = RequestRegistrarUsuarioBuilder.Construir();
        requisicao.ConfirmeSenha = string.Empty;

        var result = validator.Validate(requisicao);

        result.IsValid.Should().BeFalse();
        result.Errors.Should()
            .Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CONFIRME_SENHA_USUARIO_EMBRANCO))
            .And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SENHAS_NAO_CONFEREM));
    }

    [Fact]
    public void Validar_Erro_Email_Invalido()
    {
        var validator = new RegistrarUsuarioValidator();

        var requisicao = RequestRegistrarUsuarioBuilder.Construir();
        requisicao.ConfirmeSenha = requisicao.Senha;
        requisicao.Email = "teste";

        var result = validator.Validate(requisicao);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.EMAIL_USUARIO_INVALIDO));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void Validar_Erro_Senha_Invalida(int tamanhoSenha)
    {
        var validator = new RegistrarUsuarioValidator();

        var requisicao = RequestRegistrarUsuarioBuilder.Construir(tamanhoSenha);
        requisicao.ConfirmeSenha = requisicao.Senha;

        var resultado = validator.Validate(requisicao);

        resultado.IsValid.Should().BeFalse();
        resultado.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES));
    }





}
