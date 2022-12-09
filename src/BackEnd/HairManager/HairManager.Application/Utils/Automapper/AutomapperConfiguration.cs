using AutoMapper;
using HairManager.Comunication.Requests;
using HairManager.Domain.Entities;

namespace HairManager.Application.Utils.Automapper;
public class AutomapperConfiguration : Profile
{
	public AutomapperConfiguration()
	{
		CreateMap<RequestRegistrarUsuarioDTO, Usuario>()
			.ForMember(destino => destino.Senha, config => config.Ignore())
			.ForMember(destino => destino.ConfirmeSenha, config => config.Ignore());
	}
}
