using FluentValidation;
using HairManager.Comunication.Requests;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Usuario.Registrar;
public class RegistrarUsuarioValidator : AbstractValidator<RequestRegistrarUsuarioDTO>
{
	public RegistrarUsuarioValidator()
	{
		RuleFor(c => c.Nome).NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_USUARIO_EMBRANCO);
		RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_EMBRANCO);
		RuleFor(c => c.Senha).NotEmpty().WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO);
		RuleFor(c => c.ConfirmeSenha).NotEmpty().WithMessage(ResourceMensagensDeErro.CONFIRME_SENHA_USUARIO_EMBRANCO);
		RuleFor(c => c.Status).NotNull().WithMessage(ResourceMensagensDeErro.STATUS_USUARIO_INVALIDO);
        RuleFor(c => c.Senha)
            .Equal(c => c.ConfirmeSenha)
            .When(c => !string.IsNullOrWhiteSpace(c.Senha)).WithMessage(ResourceMensagensDeErro.SENHAS_NAO_CONFEREM);

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_INVALIDO);
        });

        When(c => !string.IsNullOrWhiteSpace(c.Senha), () =>
        {
            RuleFor(c => c.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
        });
    }
}
