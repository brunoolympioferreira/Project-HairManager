using HairManager.Domain.Entities;
using HairManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HairManager.Infra.AcessoRepositories.Repositories;

public class UsuarioRepository : IUsuarioWriteOnlyRepository, IUsuarioReadOnlyRepository
{
    private readonly HairManagerContext _context;

    public UsuarioRepository(HairManagerContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }
    public async Task<bool> ExisteUsuarioComEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(c => c.Email.Equals(email));
    }

    public async Task<Usuario> RecuperarUsuarioPorEmailESenha(string email, string senha)
    {
        return await _context.Usuarios.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Senha.Equals(senha));
    }
}
