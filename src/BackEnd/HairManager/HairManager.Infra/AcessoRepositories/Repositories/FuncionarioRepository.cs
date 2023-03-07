﻿using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace HairManager.Infra.AcessoRepositories.Repositories;
public class FuncionarioRepository : IFuncionarioWriteOnlyRepository, IFuncionarioReadOnlyRepository
{
    private readonly HairManagerContext _context;
    public FuncionarioRepository(HairManagerContext context)
    {
        _context = context;
    }
    public async Task Adicionar(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
    }

    public async Task<bool> ExisteFuncionarioComCPF(string cpf)
    {
        return await _context.Funcionarios.AnyAsync(f => f.CPF.Equals(cpf));
    }
}
