using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace HairManager.Infra.AcessoRepositories.Repositories;
public class FuncionarioRepository : IFuncionarioWriteOnlyRepository, IFuncionarioReadOnlyRepository, IFuncionarioUpdateOnlyRepository
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

    public async Task<IList<Funcionario>> GetAllFuncionarios()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    async Task<Funcionario> IFuncionarioReadOnlyRepository.GetFuncionarioPorId(long id)
    {
        return await _context.Funcionarios
            .Include(e => e.Endereco)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    async Task<Funcionario> IFuncionarioUpdateOnlyRepository.GetFuncionarioPorId(long id)
    {
        return await _context.Funcionarios
            .Include(e => e.Endereco)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public void Update(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
    }
}
