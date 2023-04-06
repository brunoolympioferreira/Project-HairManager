using HairManager.Domain.Repositories.Funcionario;
using Moq;

namespace UtilsForTests.Repositories;
public class FuncionarioReadOnlyRepositoryBuilder
{
    private static FuncionarioReadOnlyRepositoryBuilder _intance;
    private readonly Mock<IFuncionarioReadOnlyRepository> _repository;

    private FuncionarioReadOnlyRepositoryBuilder()
    {
        _repository ??= new Mock<IFuncionarioReadOnlyRepository>();
    }

    public static FuncionarioReadOnlyRepositoryBuilder Instancia()
    {
        _intance = new FuncionarioReadOnlyRepositoryBuilder();
        return _intance;
    }

    public IFuncionarioReadOnlyRepository Construir => _repository.Object;
}
