﻿namespace HairManager.Domain.Repositories.Funcionario;
public interface IFuncionarioReadOnlyRepository
{
    Task<bool> ExisteFuncionarioComCPF(string cpf);
    Task<IList<Entities.Funcionario>> GetAllFuncionarios();
    Task<Entities.Funcionario> GetFuncionarioPorId(long id);
}
