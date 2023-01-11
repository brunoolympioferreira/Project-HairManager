namespace HairManager.Domain.Repositories;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExisteUsuarioComEmail(string email);
    Task<Entities.Usuario> RecuperarUsuarioPorEmailESenha(string email, string senha);
    Task<Entities.Usuario> RecuperarUsuarioPorEmail(string email);
}
