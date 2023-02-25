using HairManager.Comunication.DTO;
using HairManager.Comunication.Enums;

namespace HairManager.Comunication.Requests;
public class RequestAdicionarFuncionarioDTO
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Nacionalidade { get; set; }
    public EnderecoDTO Endereco { get; set; }
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
}
