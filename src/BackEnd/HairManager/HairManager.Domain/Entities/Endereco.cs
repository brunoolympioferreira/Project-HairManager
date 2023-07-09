using HairManager.Domain.Enums;

namespace HairManager.Domain.Entities;
public class Endereco : BaseEntity
{
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public EstadosEnum Estado { get; set; }
    public string Pais { get; set; }
    //public virtual Funcionario Funcionario { get; set; }
}
