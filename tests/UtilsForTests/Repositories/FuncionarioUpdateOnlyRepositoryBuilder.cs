using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Funcionario;
using Moq;

namespace UtilsForTests.Repositories;
public class FuncionarioUpdateOnlyRepositoryBuilder
{
    private static FuncionarioUpdateOnlyRepositoryBuilder _instance;
    private readonly Mock<IFuncionarioUpdateOnlyRepository> _repository;

    public FuncionarioUpdateOnlyRepositoryBuilder()
    {
        _repository ??= new Mock<IFuncionarioUpdateOnlyRepository>();
    }

    public static FuncionarioUpdateOnlyRepositoryBuilder Instancia()
    {
        _instance = new FuncionarioUpdateOnlyRepositoryBuilder();
        return _instance;
    }

    public FuncionarioUpdateOnlyRepositoryBuilder RecuperarPorId(Funcionario receita)
    {
        _repository.Setup(r => r.GetFuncionarioPorId(receita.Id)).ReturnsAsync(receita);

        return this;
    }

    public IFuncionarioUpdateOnlyRepository Construir()
    {
        return _repository.Object;
    }
}
