using FluentValidation;
using HairManager.Comunication.Requests;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Usuario.AlterarSenha;
public class AlterarSenhaValidator : AbstractValidator<RequestAlterarSenhaDTO>
{
    public AlterarSenhaValidator()
    {
        RuleFor(c => c.NovaSenha).NotEmpty().WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO);

        RuleFor(c => c.NovaSenha)
        .Equal(c => c.ConfirmeNovaSenha)
        .When(c => !string.IsNullOrWhiteSpace(c.NovaSenha)).WithMessage(ResourceMensagensDeErro.SENHAS_NAO_CONFEREM);

        When(c => !string.IsNullOrWhiteSpace(c.NovaSenha), () =>
        {
            RuleFor(c => c.NovaSenha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
        });
    }
}
