using HairManager.Comunication.Requests;

namespace HairManager.Application.Services.Usuario.AlterarSenha;

public interface IAlterarSenhaService
{
    Task Executar(RequestAlterarSenhaDTO request);
}