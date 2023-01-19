using HairManager.Application.Utils.Token;
using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Usuario;
using Microsoft.AspNetCore.Http;

namespace HairManager.Application.Utils.UsuarioLogado;
public class UsuarioLogado : IUsuarioLogado
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TokenController _tokenController;
    private readonly IUsuarioReadOnlyRepository _repository;
    public UsuarioLogado(IHttpContextAccessor httpContextAccessor, TokenController tokenController, IUsuarioReadOnlyRepository repository)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenController = tokenController;
        _repository = repository;
    }
    public async Task<Usuario> RecuperarUsuario()
    {
        var authorization = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

        var token = authorization["Bearer".Length..].Trim();

        var emailUsuario = _tokenController.RecuperarEmail(token);

        var usuario = await _repository.RecuperarUsuarioPorEmail(emailUsuario);

        return usuario;
    }
}
