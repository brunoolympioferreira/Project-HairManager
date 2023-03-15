using HairManager.Domain.Enums;

namespace HairManager.Domain.Entities;
public class Funcionario : BaseEntity
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Nacionalidade { get; set; }
    public string CTPSNumero { get; set; }
    public string CTPSSerie { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string PIS { get; set; }
    public string Reservista { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public EstadoCivilEnum EstadoCivil { get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime? DataDemissao { get; set; }
    public StatusFuncionarioEnum StatusFuncionario { get; set; }
    public DateTime VencimentoFerias { get; set; }

    public long EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}
