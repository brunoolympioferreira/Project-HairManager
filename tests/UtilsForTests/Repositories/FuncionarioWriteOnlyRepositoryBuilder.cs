using HairManager.Domain.Repositories.Funcionario;
using Moq;

namespace UtilsForTests.Repositories;
public class FuncionarioWriteOnlyRepositoryBuilder
{
    private static FuncionarioWriteOnlyRepositoryBuilder _intance;
    private readonly Mock<IFuncionarioWriteOnlyRepository> _repository;

    private FuncionarioWriteOnlyRepositoryBuilder()
    {
        _repository ??= new Mock<IFuncionarioWriteOnlyRepository>();
    }

    public static FuncionarioWriteOnlyRepositoryBuilder Instancia()
    {
        _intance = new FuncionarioWriteOnlyRepositoryBuilder();
        return _intance;
    }

    public IFuncionarioWriteOnlyRepository Construir => _repository.Object;
}
