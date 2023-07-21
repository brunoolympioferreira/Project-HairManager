using HairManager.Comunication.Requests;

namespace HairManager.Application.Services.Funcionario.Atualizar;
public interface IAtualizarFuncionarioService
{
    Task Executar(long id, RequestUpdateFuncionarioDTO request);
}
