namespace HairManager.Domain.Repositories.Funcionario;
public interface IFuncionarioReadOnlyRepository
{
    Task<bool> ExisteFuncionarioComCPF(string cpf);
}
