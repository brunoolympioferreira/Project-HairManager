using HairManager.Application.Utils.Criptografia;
using HairManager.Application.Utils.Token;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using HairManager.Domain.Repositories;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Usuario.Login;
public class LoginService : ILoginService
{
    private readonly IUsuarioReadOnlyRepository _usuarioRepository;
    private readonly EncriptadorDeSenha _encriptadorSenha;
    private readonly TokenController _tokenController;

    public LoginService(IUsuarioReadOnlyRepository usuarioRepository, EncriptadorDeSenha encriptadorSenha, TokenController tokenController)
    {
        _usuarioRepository = usuarioRepository;
        _encriptadorSenha = encriptadorSenha;
        _tokenController = tokenController;
    }
    public async Task<ResponseLoginDTO> Executar(RequestLoginDTO request)
    {
        var senhaCriptografada = _encriptadorSenha.CriptografarSenha(request.Senha);

        var usuario = await _usuarioRepository.RecuperarUsuarioPorEmailESenha(request.Email, senhaCriptografada);

        Validar(usuario);

        return new ResponseLoginDTO
        {
            Nome = usuario.Nome,
            Token = _tokenController.GerarToken(usuario.Email)
        };
    }

    private static void Validar(Domain.Entities.Usuario usuario)
    {
        if (usuario == null)
        {
            throw new LoginInvalidoException();
        }
    }
}
