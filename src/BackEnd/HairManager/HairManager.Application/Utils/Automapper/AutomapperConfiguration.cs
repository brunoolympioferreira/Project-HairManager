using AutoMapper;
using HairManager.Comunication.DTO;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using HairManager.Domain.Entities;
using HashidsNet;

namespace HairManager.Application.Utils.Automapper;
public class AutomapperConfiguration : Profile
{
    private readonly IHashids _hashIds;
    public AutomapperConfiguration(IHashids hashIds)
	{
        _hashIds = hashIds;

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
        CreateMap<Funcionario, ResponseBaseDTO>()
            .ForMember(destino => destino.Id, config => config.MapFrom(origem => _hashIds.EncodeLong(origem.Id)));
        CreateMap<Endereco, ResponseEnderecoDTO>();
        CreateMap<Funcionario, ResponseListarFuncionariosDTO>();
        CreateMap<Funcionario, ResponseFuncionarioDetalhesDTO>();
    }
}
