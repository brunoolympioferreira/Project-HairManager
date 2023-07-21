namespace HairManager.Domain.Repositories.Funcionario;
public interface IFuncionarioUpdateOnlyRepository
{
    Task<Entities.Funcionario> GetFuncionarioPorId(long id);
    void Update(Entities.Funcionario funcionario);
}
