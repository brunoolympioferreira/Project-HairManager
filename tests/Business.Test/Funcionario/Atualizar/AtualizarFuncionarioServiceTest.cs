using FluentAssertions;
using HairManager.Application.Services.Funcionario.Atualizar;
using HairManager.Exceptions.ExceptionsBase;
using System;
using System.Threading.Tasks;
using UtilsForTests.Entidades;
using UtilsForTests.Mapper;
using UtilsForTests.Repositories;
using UtilsForTests.Requests;
using Xunit;

namespace Business.Test.Funcionario.Atualizar;
public class AtualizarFuncionarioServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var funcionario = FuncionarioBuilder.Construir();

        var service = CriarService(funcionario);

        var request = RequestUpdateFuncionarioBuilder.Construir();

        await service.Executar(funcionario.Id, request);

        funcionario.Telefone.Should().Be(request.Telefone);
        funcionario.Cargo.Should().Be(request.Cargo);
        funcionario.Salario.Should().Be(request.Salario);
        funcionario.EstadoCivil.Should().Be((HairManager.Domain.Enums.EstadoCivilEnum)request.EstadoCivil);
        funcionario.DataDemissao.Should().Be(request.DataDemissao);
        funcionario.StatusFuncionario.Should().Be((HairManager.Domain.Enums.StatusFuncionarioEnum)request.StatusFuncionario);

        funcionario.Endereco.Rua.Should().Be(request.Endereco.Rua);
        funcionario.Endereco.Numero.Should().Be(request.Endereco.Numero);
        funcionario.Endereco.Complemento.Should().Be(request.Endereco.Complemento);
        funcionario.Endereco.Bairro.Should().Be(request.Endereco.Bairro);
        funcionario.Endereco.Cidade.Should().Be(request.Endereco.Cidade);
        funcionario.Endereco.Estado.Should().Be((HairManager.Domain.Enums.EstadosEnum)request.Endereco.Estado);
        funcionario.Endereco.Pais.Should().Be(request.Endereco.Pais);
    }

    [Fact]
    public async Task Validar_Erro_Funcionario_Nao_Existe()
    {
        var funcionario = FuncionarioBuilder.Construir();

        var service = CriarService(funcionario);

        var request = RequestUpdateFuncionarioBuilder.Construir();

        Func<Task> acao = async () => { await service.Executar(0, request); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.FUNCIONARIO_NAO_ENCONTRADO));
    }
    private static AtualizarFuncionarioService CriarService(HairManager.Domain.Entities.Funcionario funcionario)
    {
        var repository = FuncionarioUpdateOnlyRepositoryBuilder.Instancia().RecuperarPorId(funcionario).Construir();
        var mapper = MapperBuilder.Instancia();
        var unityOfWork = UnityOfWorkBuilder.Instancia().Construir();

        return new AtualizarFuncionarioService(repository, mapper, unityOfWork);
    }
}
