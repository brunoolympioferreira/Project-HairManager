using HairManager.Domain.Enums;

namespace HairManager.Domain.Entities;
public class Funcionario : BaseEntity
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Nacionalidade { get; set; }
    public int EnderecoId { get; set; }
    public string CTPSNumero { get; set; }
    public string CTPSSerie { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string PIS { get; set; }
    public string Reservista { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public EstadoCivilEnum EstadoCivil { get; set; }
    public DateOnly DataAdmissao { get; set; }
    public DateOnly? DataDemissao { get; set; }
    public StatusFuncionarioEnum StatusFuncionario { get; set; }
    public DateOnly VencimentoFerias { get; set; }

    public virtual Endereco Endereco { get; set; }
}
