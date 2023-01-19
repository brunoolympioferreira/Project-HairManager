namespace HairManager.Domain.Repositories.Usuario;
public interface IUsuarioUpdateOnlyRepository
{
    void Update(Entities.Usuario usuario);
    Task<Entities.Usuario> RecuperarPorId(long id);
}
