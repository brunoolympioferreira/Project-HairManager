using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Usuario.RecuperarPerfil;

public interface IRecuperarPerfilService
{
    Task<ResponsePerfilUsuarioDTO> Executar();
}