using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Funcionario;
using Moq;
using System.Collections.Generic;

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

    public FuncionarioReadOnlyRepositoryBuilder RecuperarTodosFuncionarios(Funcionario funcionario)
    {
        if (funcionario is not null)
             _repository.Setup(f => f.GetAllFuncionarios()).ReturnsAsync(new List<Funcionario> { funcionario });
        return this;
    }

    public IFuncionarioReadOnlyRepository Construir => _repository.Object;
}
