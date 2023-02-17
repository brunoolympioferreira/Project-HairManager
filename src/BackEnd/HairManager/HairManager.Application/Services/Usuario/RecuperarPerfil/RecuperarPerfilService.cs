using AutoMapper;
using HairManager.Application.Utils.UsuarioLogado;
using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Usuario.RecuperarPerfil;
public class RecuperarPerfilService : IRecuperarPerfilService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioLogado _usuarioLogado;
    public RecuperarPerfilService(IMapper mapper, IUsuarioLogado usuarioLogado)
    {
        _mapper = mapper;
        _usuarioLogado = usuarioLogado;
    }
    public async Task<ResponsePerfilUsuarioDTO> Executar()
    {
        var usuario = await _usuarioLogado.RecuperarUsuario();

        return _mapper.Map<ResponsePerfilUsuarioDTO>(usuario);
    }
}
