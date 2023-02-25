using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Funcionario;

namespace HairManager.Infra.AcessoRepositories.Repositories;
public class FuncionarioRepository : IFuncionarioWriteOnlyRepository
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
}
