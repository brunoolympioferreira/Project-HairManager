using HairManager.Comunication.Enums;

namespace HairManager.Comunication.Responses;
public class ResponseEnderecoDTO
{
    public long EnderecoId { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public EstadosEnum Estado { get; set; }
    public string Pais { get; set; }
}
