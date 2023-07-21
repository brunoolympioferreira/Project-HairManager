using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Funcionario.Adicionar;
public interface IAdicionarFuncionarioService
{
    Task<ResponseBaseDTO> Executar(RequestFuncionarioDTO request);
}
