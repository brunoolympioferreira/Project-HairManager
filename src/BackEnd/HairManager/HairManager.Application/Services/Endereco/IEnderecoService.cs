using HairManager.Comunication.DTO;
using HairManager.Comunication.Responses;

namespace HairManager.Application.Services.Endereco;
public interface IEnderecoService
{
    Task<ResponseEnderecoDTO> Executar(EnderecoDTO enderecoDTO);
}
