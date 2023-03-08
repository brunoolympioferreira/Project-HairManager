using FluentValidation;
using HairManager.Comunication.DTO;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Endereco;
public class EnderecoValidator : AbstractValidator<EnderecoDTO>
{
	public EnderecoValidator()
	{
		RuleFor(c => c.Rua)
			.NotEmpty().WithMessage(ResourceMensagensDeErro.RUA_EMBRANCO);
        RuleFor(c => c.Numero)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.NUMERO_EMBRANCO);
        RuleFor(c => c.Bairro)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.BAIRRO_EMBRANCO);
        RuleFor(c => c.Cidade)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.CIDADE_EMBRANCO);
        RuleFor(c => c.Estado)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.ESTADO_EMBRANCO);
        RuleFor(c => c.Pais)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.PAIS_EMBRANCO);

    }
}
