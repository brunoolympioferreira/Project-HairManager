using FluentValidation;
using HairManager.Comunication.Requests;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Usuario.AlterarSenha;
public class AlterarSenhaValidator : AbstractValidator<RequestAlterarSenhaDTO>
{
    public AlterarSenhaValidator()
    {
        RuleFor(c => c.SenhaAtual).NotEmpty().WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_EMBRANCO);

        RuleFor(c => c.SenhaAtual)
        .Equal(c => c.ConfirmeNovaSenha)
        .When(c => !string.IsNullOrWhiteSpace(c.SenhaAtual)).WithMessage(ResourceMensagensDeErro.SENHAS_NAO_CONFEREM);

        When(c => !string.IsNullOrWhiteSpace(c.SenhaAtual), () =>
        {
            RuleFor(c => c.SenhaAtual.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
        });
    }
}
