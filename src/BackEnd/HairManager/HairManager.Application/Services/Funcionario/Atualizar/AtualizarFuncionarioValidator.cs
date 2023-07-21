using FluentValidation;
using HairManager.Application.Utils.FluentValidatorExtensions;
using HairManager.Comunication.Requests;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Funcionario.Atualizar;
public class AtualizarFuncionarioValidator : AbstractValidator<RequestUpdateFuncionarioDTO>
{
    public AtualizarFuncionarioValidator()
    {
        RuleFor(c => c.Telefone)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.TELEFONE_FUNCIONARIO_EMBRANCO);
        When(c => !string.IsNullOrWhiteSpace(c.Telefone), () =>
        {
            RuleFor(c => c.Telefone).Phone().WithMessage(ResourceMensagensDeErro.TELEFONE_FUNCIONARIO_INVALIDO);
        });

        RuleFor(c => c.Cargo)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.CARGO_EMBRANCO);

        RuleFor(c => c.Salario)
            .GreaterThan(0).WithMessage(ResourceMensagensDeErro.SALARIO_INVALIDO);
    }
}
