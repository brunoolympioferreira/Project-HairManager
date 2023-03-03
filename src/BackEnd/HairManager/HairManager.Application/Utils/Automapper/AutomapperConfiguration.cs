using AutoMapper;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using HairManager.Domain.Entities;

namespace HairManager.Application.Utils.Automapper;
public class AutomapperConfiguration : Profile
{
	public AutomapperConfiguration()
	{
		RequestForEntity();
		EntityForResponse();
    }

	private void RequestForEntity()
	{
        CreateMap<RequestRegistrarUsuarioDTO, Usuario>()
            .ForMember(destino => destino.Senha, config => config.Ignore())
            .ForMember(destino => destino.ConfirmeSenha, config => config.Ignore());

		CreateMap<EnderecoDTO, Endereco>();
    }

	private void EntityForResponse()
	{
		CreateMap<Usuario, ResponsePerfilUsuarioDTO>();
	}
}
