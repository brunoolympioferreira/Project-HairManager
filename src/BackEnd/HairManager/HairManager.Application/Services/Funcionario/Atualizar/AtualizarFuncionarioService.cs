using AutoMapper;
using HairManager.Comunication.Requests;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Funcionario;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Funcionario.Atualizar;
public class AtualizarFuncionarioService : IAtualizarFuncionarioService
{
    private readonly IFuncionarioUpdateOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    public AtualizarFuncionarioService(IFuncionarioUpdateOnlyRepository repository, IMapper mapper, IUnityOfWork unityOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unityOfWork = unityOfWork;
    }
    public async Task Executar(long id, RequestUpdateFuncionarioDTO request)
    {
        var funcionario = await _repository.GetFuncionarioPorId(id);

        Validar(request, funcionario);

        funcionario.UpdatedAt = DateTime.Now;
        funcionario.Endereco.UpdatedAt = DateTime.Now;

        _mapper.Map(request, funcionario);

        _repository.Update(funcionario);

        await _unityOfWork.Commit();
    }

    public static void Validar(RequestUpdateFuncionarioDTO request, Domain.Entities.Funcionario funcionario)
    {
        if (funcionario is null)
        {
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.FUNCIONARIO_NAO_ENCONTRADO });
        }

        AtualizarFuncionarioValidator validator = new AtualizarFuncionarioValidator();
        FluentValidation.Results.ValidationResult result = validator.Validate(request);

        if (!result.IsValid) 
        {
            List<string> errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(errorMessages);
        }
    }
}
