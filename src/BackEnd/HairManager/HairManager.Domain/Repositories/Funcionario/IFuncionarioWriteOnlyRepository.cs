namespace HairManager.Domain.Repositories.Funcionario;
public interface IFuncionarioWriteOnlyRepository
{
    Task Adicionar(Entities.Funcionario funcionario);
}
