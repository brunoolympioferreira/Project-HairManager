using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Shared;

namespace HairManager.Infra.AcessoRepositories.Repositories;
public class EnderecoRepository : IEnderecoWriteOnlyRepository
{
    private readonly HairManagerContext _context;
    public EnderecoRepository(HairManagerContext context)
    {
        _context = context;
    }
    public async Task Adicionar(Endereco endereco)
    {
        await _context.Enderecos.AddAsync(endereco);
    }
}
