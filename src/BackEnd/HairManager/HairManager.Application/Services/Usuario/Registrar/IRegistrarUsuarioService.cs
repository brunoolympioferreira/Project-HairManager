using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Usuario.Registrar;
public interface IRegistrarUsuarioService
{
    Task<ResponseUsuarioRegistradoDTO> Executar(RequestRegistrarUsuarioDTO request);
}
