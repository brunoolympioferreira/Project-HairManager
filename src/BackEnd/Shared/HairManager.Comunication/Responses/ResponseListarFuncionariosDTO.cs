using HairManager.Comunication.Enums;

namespace HairManager.Comunication.Responses;
public class ResponseListarFuncionariosDTO : ResponseBaseDTO
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Cargo { get; set; }
    public DateTime DataAdmissao { get; set; }
    public StatusFuncionarioEnum StatusFuncionario { get; set; }
}
