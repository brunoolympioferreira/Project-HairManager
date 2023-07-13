using FluentAssertions;
using HairManager.Application.Services.Funcionario.RecuperarPorId;
using HairManager.Comunication.Responses;
using HairManager.Domain.Repositories.Funcionario;
using HairManager.Exceptions.ExceptionsBase;
using System;
using System.Threading.Tasks;
using UtilsForTests.Entidades;
using UtilsForTests.Mapper;
using UtilsForTests.Repositories;
using Xunit;

namespace Business.Test.Funcionario.RecuperarPorId;
public class RecuperarFuncionarioPorIdServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        HairManager.Domain.Entities.Funcionario funcionario = FuncionarioBuilder.Construir();
        RecuperarFuncionarioPorIdService service = CriarService(funcionario);

        ResponseFuncionarioDetalhesDTO response = await service.Executar(funcionario.Id);

        response.Nome.Should().Be(funcionario.Nome);
        response.Telefone.Should().Be(funcionario.Telefone);
        response.DataNascimento.Should().Be(funcionario.DataNascimento);
        response.Nacionalidade.Should().Be(funcionario.Nacionalidade);
        response.CTPSNumero.Should().Be(funcionario.CTPSNumero);
        response.CTPSSerie.Should().Be(funcionario.CTPSSerie);
        response.CPF.Should().Be(funcionario.CPF);
        response.RG.Should().Be(funcionario.RG);
        response.PIS.Should().Be(funcionario.PIS);
        response.Reservista.Should().Be(funcionario.Reservista);
        response.Cargo.Should().Be(funcionario.Cargo);
        response.Salario.Should().Be(funcionario.Salario);
        response.Salario.Should().Be(funcionario.Salario);
        response.EstadoCivil.Should().Be((HairManager.Comunication.Enums.EstadoCivilEnum)funcionario.EstadoCivil);
        response.DataAdmissao.Should().Be(funcionario.DataAdmissao);
        response.DataDemissao.Should().Be(funcionario.DataDemissao);
        response.StatusFuncionario.Should().Be((HairManager.Comunication.Enums.StatusFuncionarioEnum)funcionario.StatusFuncionario);

        response.Endereco.Rua.Should().Be(funcionario.Endereco.Rua);
        response.Endereco.Numero.Should().Be(funcionario.Endereco.Numero);
        response.Endereco.Complemento.Should().Be(funcionario.Endereco.Complemento);
        response.Endereco.Bairro.Should().Be(funcionario.Endereco.Bairro);
        response.Endereco.Cidade.Should().Be(funcionario.Endereco.Cidade);
        response.Endereco.Estado.Should().Be((HairManager.Comunication.Enums.EstadosEnum)funcionario.Endereco.Estado);
        response.Endereco.Pais.Should().Be(funcionario.Endereco.Pais);
    }

    [Fact]
    public async Task Validar_Erro_Funcionario_Nao_Existe()
    {
        HairManager.Domain.Entities.Funcionario funcionario = FuncionarioBuilder.Construir();

        RecuperarFuncionarioPorIdService service = CriarService(funcionario);

        Func<Task> acao = async () => { await service.Executar(0); };

        await acao.Should().ThrowAsync<ErrosDeValidacaoException>()
            .Where(ex => ex.MensagensDeErro.Count == 1 && ex.MensagensDeErro.Contains(ResourceMensagensDeErro.FUNCIONARIO_NAO_ENCONTRADO));
    }
    private static RecuperarFuncionarioPorIdService CriarService(HairManager.Domain.Entities.Funcionario funcionario)
    {
        IFuncionarioReadOnlyRepository repository = FuncionarioReadOnlyRepositoryBuilder.Instancia().RecuperarPorId(funcionario).Construir;
        AutoMapper.IMapper mapper = MapperBuilder.Instancia();

        return new RecuperarFuncionarioPorIdService(repository, mapper);
    }
}
