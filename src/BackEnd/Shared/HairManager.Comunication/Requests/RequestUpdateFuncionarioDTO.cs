using HairManager.Comunication.DTO;
using HairManager.Comunication.Enums;

namespace HairManager.Comunication.Requests;
public class RequestUpdateFuncionarioDTO
{
    public string Telefone { get; set; }
    public EnderecoDTO Endereco { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public EstadoCivilEnum EstadoCivil { get; set; }
    public DateTime? DataDemissao { get; set; }
    public StatusFuncionarioEnum StatusFuncionario { get; set; }
}
