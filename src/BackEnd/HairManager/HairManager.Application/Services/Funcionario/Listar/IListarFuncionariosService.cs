using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Funcionario.Listar;
public interface IListarFuncionariosService
{
    Task<List<ResponseListarFuncionariosDTO>> Executar();
}
