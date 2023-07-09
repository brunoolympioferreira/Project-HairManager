using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Funcionario.RecuperarPorId;
public interface IRecuperarFuncionarioPorIdService
{
    Task<ResponseFuncionarioDetalhesDTO> Executar(long id);
}
