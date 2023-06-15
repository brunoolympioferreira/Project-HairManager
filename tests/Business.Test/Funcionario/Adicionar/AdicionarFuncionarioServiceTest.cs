using AutoMapper;
using Business.Test.Endereco;
using FluentAssertions;
using HairManager.Application.Services.Endereco;
using HairManager.Application.Services.Funcionario.Adicionar;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Funcionario;
using System.Threading.Tasks;
using UtilsForTests.Entidades;
using UtilsForTests.Mapper;
using UtilsForTests.Repositories;
using UtilsForTests.Requests;
using Xunit;

namespace Business.Test.Funcionario.Adicionar;
public class AdicionarFuncionarioServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        HairManager.Domain.Entities.Funcionario funcionario = FuncionarioBuilder.Construir();

        AdicionarFuncionarioService service = CriarService(funcionario);

        RequestAdicionarFuncionarioDTO request = RequestFuncionarioBuilder.Construir();
        ResponseBaseDTO response = await service.Executar(request);

        response.Should().NotBeNull();
        response.Should().NotBeNull();
    }

    private static AdicionarFuncionarioService CriarService(HairManager.Domain.Entities.Funcionario funcionario)
    {
        IMapper mapper = MapperBuilder.Instancia();
        IUnityOfWork unityOfWork = UnityOfWorkBuilder.Instancia().Construir();
        IFuncionarioWriteOnlyRepository funcionarioWriteOnlyRepository = FuncionarioWriteOnlyRepositoryBuilder.Instancia().Construir;
        EnderecoService enderecoService = EnderecoServiceTest.Instancia();
        IFuncionarioReadOnlyRepository funcionarioReadOnlyRepository = FuncionarioReadOnlyRepositoryBuilder.Instancia().Construir;

        return new AdicionarFuncionarioService(mapper, unityOfWork, funcionarioWriteOnlyRepository, enderecoService, funcionarioReadOnlyRepository);
    }
}
