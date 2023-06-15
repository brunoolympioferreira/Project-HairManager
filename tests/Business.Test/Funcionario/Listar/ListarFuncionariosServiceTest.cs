using FluentAssertions;
using HairManager.Application.Services.Funcionario.Listar;
using System.Linq;
using System.Threading.Tasks;
using UtilsForTests.Entidades;
using UtilsForTests.Mapper;
using UtilsForTests.Repositories;
using Xunit;

namespace Business.Test.Funcionario.Listar;
public class ListarFuncionariosServiceTest
{
    [Fact]
    public async Task Validar_Sucesso()
    {
        var funcionario = FuncionarioBuilder.Construir();
        var service = CriarService(funcionario);

        var response = await service.Executar();

        response.FirstOrDefault().Should();
    }
    private static ListarFuncionariosService CriarService(HairManager.Domain.Entities.Funcionario funcionario)
    {
        var repository = FuncionarioReadOnlyRepositoryBuilder.Instancia().RecuperarTodosFuncionarios(funcionario).Construir;
        var mapper = MapperBuilder.Instancia();

        return new ListarFuncionariosService(repository, mapper);
    }
}
