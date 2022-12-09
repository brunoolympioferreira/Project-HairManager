namespace HairManager.Domain.Repositories;

public interface IUsuarioReadOnlyRepository
{
    Task<bool> ExisteUsuarioComEmail(string email);
    Task<bool> ConferirSenhas(string senha, string confirmeSenha);
}
