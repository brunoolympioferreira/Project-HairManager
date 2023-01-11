namespace HairManager.Application.Utils.UsuarioLogado;
public interface IUsuarioLogado
{
    Task<Domain.Entities.Usuario> RecuperarUsuario();
}
