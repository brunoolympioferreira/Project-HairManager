using FluentValidation;
using HairManager.Application.Utils.FluentValidatorExtensions;
using HairManager.Comunication.Requests;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Funcionario;
public class AdicionarFuncionarioValidator : AbstractValidator<RequestAdicionarFuncionarioDTO>
{
    public AdicionarFuncionarioValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_FUNCIONARIO_EMBRANCO);
        When(c => !string.IsNullOrWhiteSpace(c.Nome), () =>
        {
            RuleFor(c => c.Nome).Length(3, 50).WithMessage(ResourceMensagensDeErro.NOME_FUNCIONARIO_INVALIDO);
        });

        RuleFor(c => c.Telefone)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.TELEFONE_FUNCIONARIO_EMBRANCO);
        When(c => !string.IsNullOrWhiteSpace(c.Telefone), () =>
        {
            RuleFor(c => c.Telefone).Phone().WithMessage(ResourceMensagensDeErro.TELEFONE_FUNCIONARIO_INVALIDO);
        });
        RuleFor(c => c.DataNascimento)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.DATA_EMBRANCO);
        RuleFor(c => c.Nacionalidade)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.NACIONALIDADE_EMBRANCO);
        RuleFor(c => c.CTPSNumero)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.CTPS_NUMERO_EMBRANCO);
        RuleFor(c => c.CTPSSerie)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.CTPS_SERIE_EMBRANCO);
        RuleFor(c => c.CPF)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.CPF_EMBRANCO);          
        When(c => !string.IsNullOrWhiteSpace(c.CPF), () =>
        {
            RuleFor(c => c.CPF).IsValidCPF().WithMessage(ResourceMensagensDeErro.CPF_INVALIDO);
        });
        RuleFor(c => c.RG)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.RG_EMBRANCO);
        RuleFor(c => c.PIS)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.PIS_EMBRANCO);
        RuleFor(c => c.Cargo)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.CARGO_EMBRANCO);

        RuleFor(c => c.Salario)
            .GreaterThan(0).WithMessage(ResourceMensagensDeErro.SALARIO_INVALIDO);
        RuleFor(c => c.DataAdmissao)
            .NotEmpty().WithMessage(ResourceMensagensDeErro.DATA_EMBRANCO);
    }
}
