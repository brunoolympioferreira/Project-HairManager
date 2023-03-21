using AutoMapper;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Responses;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Endereco;
public class EnderecoService : IEnderecoService
{
    private readonly IMapper _mapper;
    public EnderecoService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public ResponseEnderecoDTO Executar(EnderecoDTO enderecoDTO)
    {
        Validar(enderecoDTO);

        Domain.Entities.Endereco endereco = _mapper.Map<Domain.Entities.Endereco>(enderecoDTO);

        ResponseEnderecoDTO response = _mapper.Map<ResponseEnderecoDTO>(endereco);

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
