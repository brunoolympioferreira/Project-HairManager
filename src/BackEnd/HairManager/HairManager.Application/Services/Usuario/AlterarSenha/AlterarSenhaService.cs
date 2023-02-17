using FluentValidation.Results;
using HairManager.Application.Utils.Criptografia;
using HairManager.Application.Utils.UsuarioLogado;
using HairManager.Comunication.Requests;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Usuario;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Usuario.AlterarSenha;
public class AlterarSenhaService : IAlterarSenhaService
{
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly IUsuarioUpdateOnlyRepository _repository;
    private readonly EncriptadorDeSenha _encriptadorSenha;
    private readonly IUnityOfWork _unityOfWork;
    public AlterarSenhaService(
        IUsuarioLogado usuarioLogado, 
        IUsuarioUpdateOnlyRepository repository, 
        EncriptadorDeSenha encriptadorSenha, 
        IUnityOfWork unityOfWork)
    {
        _usuarioLogado = usuarioLogado;
        _repository = repository;
        _encriptadorSenha = encriptadorSenha;
        _unityOfWork = unityOfWork;
    }
    public async Task Executar(RequestAlterarSenhaDTO request)
    {
        Domain.Entities.Usuario usuarioLogado = await _usuarioLogado.RecuperarUsuario();

        Domain.Entities.Usuario usuario = await _repository.RecuperarPorId(usuarioLogado.Id);

        Validar(request, usuario);

        usuario.Senha = _encriptadorSenha.CriptografarSenha(request.NovaSenha);
        usuario.ConfirmeSenha = _encriptadorSenha.CriptografarConfirmeSenha(request.ConfirmeNovaSenha);

        _repository.Update(usuario);

        await _unityOfWork.Commit();
    }

    private void Validar(RequestAlterarSenhaDTO request, Domain.Entities.Usuario usuario)
    {
        var validator = new AlterarSenhaValidator();
        ValidationResult result = validator.Validate(request);

        string senhaAtualCriptografada = _encriptadorSenha.CriptografarSenha(request.SenhaAtual);

        if (!usuario.Senha.Equals(senhaAtualCriptografada))
        {
            result.Errors.Add(new ValidationFailure("senhaAtual", ResourceMensagensDeErro.SENHA_ATUAL_INVALIDA));
        }

        if (!result.IsValid)
        {
            List<string> mensagens = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagens);
        }
    }
}
