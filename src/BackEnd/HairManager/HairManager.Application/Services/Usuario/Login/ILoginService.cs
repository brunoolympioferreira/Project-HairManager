using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Usuario.Login;
public interface ILoginService
{
    Task<ResponseLoginDTO> Executar(RequestLoginDTO request);
}
