using AutoMapper;
using FluentValidation.Results;
using HairManager.Application.Utils.Criptografia;
using HairManager.Application.Utils.Token;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Usuario;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Usuario.Registrar;
public class RegistrarUsuarioService : IRegistrarUsuarioService
{
    private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
    private readonly IUsuarioWriteOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    private readonly EncriptadorDeSenha _encriptadorDeSenha;
    private readonly TokenController _tokenController;

    public RegistrarUsuarioService(
        IUsuarioReadOnlyRepository usuarioReadOnlyRepository,
        IUsuarioWriteOnlyRepository usuarioWriteOnlyRepository,
        IMapper mapper,
        IUnityOfWork unityOfWork,
        EncriptadorDeSenha encriptadorDeSenha,
        TokenController tokenController)
    {
        _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
        _repository = usuarioWriteOnlyRepository;
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }
    public async Task<ResponseUsuarioRegistradoDTO> Executar(RequestRegistrarUsuarioDTO request)
    {
        await Validar(request);

        var entity = _mapper.Map<Domain.Entities.Usuario>(request);
        entity.Senha = _encriptadorDeSenha.CriptografarSenha(request.Senha);
        entity.ConfirmeSenha = _encriptadorDeSenha.CriptografarConfirmeSenha(request.ConfirmeSenha);

        await _repository.Adicionar(entity);

        await _unityOfWork.Commit();

        var token = _tokenController.GerarToken(entity.Email);

        return new ResponseUsuarioRegistradoDTO
        {
            Token = token,
            Nome = entity.Nome
        };
    }

    private async Task Validar(RequestRegistrarUsuarioDTO request)
    {
        var validator = new RegistrarUsuarioValidator();
        var result = validator.Validate(request);

        var existeUsuarioComEmail = await _usuarioReadOnlyRepository.ExisteUsuarioComEmail(request.Email);
        if (existeUsuarioComEmail)
        {
            result.Errors.Add(new ValidationFailure("email", ResourceMensagensDeErro.EMAIL_JA_CADASTRADO));
        }

        if (!result.IsValid)
        {
            var mensagensDeErro = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }
}
