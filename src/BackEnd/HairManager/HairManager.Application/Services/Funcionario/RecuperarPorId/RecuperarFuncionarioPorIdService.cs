using AutoMapper;
using HairManager.Comunication.Responses;
using HairManager.Domain.Entities;
using HairManager.Domain.Repositories.Funcionario;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Funcionario.RecuperarPorId;
public class RecuperarFuncionarioPorIdService : IRecuperarFuncionarioPorIdService
{
    private readonly IFuncionarioReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public RecuperarFuncionarioPorIdService(IFuncionarioReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseFuncionarioDetalhesDTO> Executar(long id)
    {
        Domain.Entities.Funcionario funcionario = await _repository.GetFuncionarioPorId(id);

        Validar(funcionario);

        return _mapper.Map<Domain.Entities.Funcionario, ResponseFuncionarioDetalhesDTO>(funcionario);
    }

    public static void Validar(Domain.Entities.Funcionario funcionario)
    {
        if (funcionario is null)
            throw new ErrosDeValidacaoException(new List<string> { ResourceMensagensDeErro.FUNCIONARIO_NAO_ENCONTRADO });
    }
}
