using AutoMapper;
using HairManager.Application.Utils.UsuarioLogado;
using HairManager.Comunication.Responses;
using HairManager.Domain.Repositories.Funcionario;

namespace HairManager.Application.Services.Funcionario.Listar;
public class ListarFuncionariosService : IListarFuncionariosService
{
    private readonly IFuncionarioReadOnlyRepository _repository;
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly IMapper _mapper;
    public ListarFuncionariosService(IFuncionarioReadOnlyRepository repository, IUsuarioLogado usuarioLogado, IMapper mapper)
    {
        _repository = repository;
        _usuarioLogado = usuarioLogado;
        _mapper = mapper;
    }

    public async Task<List<ResponseListarFuncionariosDTO>> Executar()
    {
        var funcionarios = await _repository.GetAllFuncionarios();

        var funcionariosDTO = _mapper.Map<List<ResponseListarFuncionariosDTO>>(funcionarios);

        return funcionariosDTO;
    }
}
