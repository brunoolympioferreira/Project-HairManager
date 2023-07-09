using AutoMapper;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using HairManager.Domain.Entities;
using HashidsNet;

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
		CreateMap<ResponseEnderecoDTO, Endereco>();
    }

	private void EntityForResponse()
	{
		CreateMap<Usuario, ResponsePerfilUsuarioDTO>();
        CreateMap<Funcionario, ResponseBaseDTO>();
        CreateMap<Endereco, ResponseEnderecoDTO>();
        CreateMap<Funcionario, ResponseListarFuncionariosDTO>();
        CreateMap<Funcionario, ResponseFuncionarioDetalhesDTO>();
        CreateMap<Endereco, EnderecoDTO>();
    }
}
