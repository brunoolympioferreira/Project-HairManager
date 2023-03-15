using AutoMapper;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Requests;
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

    public ResponseEnderecoDTO Executar(EnderecoDTO enderecoDTO)
    {
        Validar(enderecoDTO);

        Domain.Entities.Endereco endereco = _mapper.Map<Domain.Entities.Endereco>(enderecoDTO);

        //_repository.Adicionar(endereco);

        var response = _mapper.Map<ResponseEnderecoDTO>(endereco);

        return response;
    }

    private static void Validar(EnderecoDTO enderecoDTO)
    {
        EnderecoValidator validator = new EnderecoValidator();
        FluentValidation.Results.ValidationResult result = validator.Validate(enderecoDTO);

        if (!result.IsValid)
        {
            List<string> errorMessages = result.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(errorMessages);
        }
    }
}
