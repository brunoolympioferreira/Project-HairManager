using FluentAssertions;
using HairManager.Application.Services.Endereco;
using HairManager.Application.Services.Funcionario;
using HairManager.Application.Services.Funcionario.Adicionar;
using HairManager.Exceptions.ExceptionsBase;
using UtilsForTests.Requests;
using Xunit;

namespace Validators.Test.Funcionario.Adicionar;
public class AdicionarFuncionarioValidatorTest
{
    [Fact]
    public void Validar_Sucesso()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validar_Erro_Nome_EMBRANCO()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Nome = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NOME_FUNCIONARIO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Nome_Invalido()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Nome = "Morbi a metus. Phasellus enim erat, vestibulum vel, aliquam a,";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NOME_FUNCIONARIO_INVALIDO));
    }

    [Fact]
    public void Validar_Erro_Telefone_EmBranco()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Telefone = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.TELEFONE_FUNCIONARIO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Telefone_Invalido()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Telefone = "1234";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.TELEFONE_FUNCIONARIO_INVALIDO));
    }

    [Fact]
    public void Validar_Erro_Nacionalidade_EmBranco()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Nacionalidade = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NACIONALIDADE_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_CTPS_Numero_EmBranco()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.CTPSNumero = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CTPS_NUMERO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_CTPS_Serie_EmBranco()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.CTPSSerie = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CTPS_SERIE_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_CPF_Invalido()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.CPF = "12345678910";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CPF_INVALIDO));
    }

    [Fact]
    public void Validar_Erro_CPF_EMBRANCO()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.CPF = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CPF_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_RG_EMBRANCO()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.RG = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.RG_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_PIS_EMBRANCO()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.PIS = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.PIS_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Cargo_EMBRANCO()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Cargo = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CARGO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Salario_Invalido()
    {
        var validator = new AdicionarFuncionarioValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Salario = 0;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.SALARIO_INVALIDO));
    }

    [Fact]
    public void Validar_Erro_Rua_EmBranco()
    {
        var validator = new EnderecoValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Endereco.Rua = string.Empty;

        var result = validator.Validate(request.Endereco);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.RUA_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Numero_EmBranco()
    {
        var validator = new EnderecoValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Endereco.Numero = string.Empty;

        var result = validator.Validate(request.Endereco);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.NUMERO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Bairro_EmBranco()
    {
        var validator = new EnderecoValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Endereco.Bairro = string.Empty;

        var result = validator.Validate(request.Endereco);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.BAIRRO_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Cidade_EmBranco()
    {
        var validator = new EnderecoValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Endereco.Cidade = string.Empty;

        var result = validator.Validate(request.Endereco);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.CIDADE_EMBRANCO));
    }

    [Fact]
    public void Validar_Erro_Pais_EmBranco()
    {
        var validator = new EnderecoValidator();

        var request = RequestFuncionarioBuilder.Construir();
        request.Endereco.Pais = string.Empty;

        var result = validator.Validate(request.Endereco);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceMensagensDeErro.PAIS_EMBRANCO));
    }
}
