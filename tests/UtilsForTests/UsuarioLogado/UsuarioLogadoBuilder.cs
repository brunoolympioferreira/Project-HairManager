using HairManager.Application.Utils.UsuarioLogado;
using Moq;

namespace UtilsForTests.UsuarioLogado;
public class UsuarioLogadoBuilder
{
    private static UsuarioLogadoBuilder _instance;
    private readonly Mock<IUsuarioLogado> _repository;

    public UsuarioLogadoBuilder()
    {
        _repository = new Mock<IUsuarioLogado>();
    }

    public static UsuarioLogadoBuilder Instancia()
    {
        _instance = new UsuarioLogadoBuilder();
        return _instance;
    }

    public UsuarioLogadoBuilder RecuperarUsuario(HairManager.Domain.Entities.Usuario usuario)
    {
        _repository.Setup(c => c.RecuperarUsuario()).ReturnsAsync(usuario);

        return this;
    }

    public IUsuarioLogado Construir()
    {
        return _repository.Object;
    }
}
