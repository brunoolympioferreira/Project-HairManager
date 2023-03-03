using AutoMapper;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Responses;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Shared;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Endereco;
public class EnderecoService : IEnderecoService
{
	private readonly IMapper _mapper;
	private readonly IUnityOfWork _unityOfWork;
    private readonly IEnderecoWriteOnlyRepository _repository;
    public EnderecoService(IMapper mapper, IUnityOfWork unityOfWork, IEnderecoWriteOnlyRepository repository)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _repository = repository;
    }

    public async Task<ResponseEnderecoDTO> Executar(EnderecoDTO enderecoDTO)
    {
        Validar(enderecoDTO);

        var endereco = _mapper.Map<Domain.Entities.Endereco>(enderecoDTO);

        await _repository.Adicionar(endereco);

        await _unityOfWork.Commit();

        return _mapper.Map<ResponseEnderecoDTO>(endereco);
    }

    private static void Validar(EnderecoDTO enderecoDTO)
    {
        var validator = new EnderecoValidator();
        var result = validator.Validate(enderecoDTO);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(errorMessages);
        }
    }
}
