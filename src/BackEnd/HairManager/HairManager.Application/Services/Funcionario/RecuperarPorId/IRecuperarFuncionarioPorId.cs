using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Funcionario.RecuperarPorId;
public interface IRecuperarFuncionarioPorId
{
    Task<ResponseFuncionarioDetalhesDTO> Executar(long id);
}
