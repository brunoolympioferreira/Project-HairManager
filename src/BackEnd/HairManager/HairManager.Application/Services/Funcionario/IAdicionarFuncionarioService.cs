using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Funcionario;
public interface IAdicionarFuncionarioService
{
    Task<ResponseBaseDTO> Executar(RequestAdicionarFuncionarioDTO request);
}
