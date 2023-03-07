using AutoMapper;
using HairManager.Application.Services.Endereco;
using HairManager.Comunication.Requests;
using HairManager.Comunication.Responses;
using HairManager.Domain.Enums;
using HairManager.Domain.Repositories;
using HairManager.Domain.Repositories.Funcionario;
using HairManager.Exceptions.ExceptionsBase;

namespace HairManager.Application.Services.Funcionario;
public class AdicionarFuncionarioService : IAdicionarFuncionarioService
{
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IFuncionarioWriteOnlyRepository _repository;
    private readonly IEnderecoService _enderecoService;
    private readonly IFuncionarioReadOnlyRepository _readOnlyRepository;
    public AdicionarFuncionarioService(IMapper mapper,
        IUnityOfWork unityOfWork,
        IFuncionarioWriteOnlyRepository repository,
        IEnderecoService enderecoService,
        IFuncionarioReadOnlyRepository readOnlyRepository)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _repository = repository;
        _enderecoService = enderecoService;
        _readOnlyRepository = readOnlyRepository;
    }
    public async Task<ResponseBaseDTO> Executar(RequestAdicionarFuncionarioDTO request)
    {
        await Validar(request);

        var funcionario = FuncionarioMapping(request);

        await _repository.Adicionar(funcionario);

        await _unityOfWork.Commit();

        return _mapper.Map<ResponseBaseDTO>(request);
    }

    private async Task Validar(RequestAdicionarFuncionarioDTO request)
    {
        var validator = new AdicionarFuncionarioValidator();
        var result = validator.Validate(request);

        var existeFuncionarioComCPF = await _readOnlyRepository.ExisteFuncionarioComCPF(request.CPF);
        if (existeFuncionarioComCPF)
            result.Errors.Add(new FluentValidation.Results.ValidationFailure("cpf", ResourceMensagensDeErro.CPF_JA_CADASTRADO));

        if (!result.IsValid)
        {
            var mensagensDeErro = result.Errors.Select(c => c.ErrorMessage).ToList();
            throw new ErrosDeValidacaoException(mensagensDeErro);
        }
    }

    private Domain.Entities.Funcionario FuncionarioMapping(RequestAdicionarFuncionarioDTO request)
    {
        var endereco = _enderecoService.Executar(request.Endereco);

        var result = new Domain.Entities.Funcionario()
        {
            Nome = request.Nome,
            Telefone = request.Telefone,
            DataNascimento = request.DataNascimento,
            Nacionalidade = request.Nacionalidade,
            CTPSNumero = request.CTPSNumero,
            CTPSSerie = request.CTPSSerie,
            CPF = request.CPF,
            RG = request.RG,
            PIS = request.PIS,
            Reservista = request.Reservista,
            Cargo = request.Cargo,
            Salario = request.Salario,
            EstadoCivil = (EstadoCivilEnum)request.EstadoCivil,
            DataAdmissao = request.DataAdmissao,
            DataDemissao = request.DataDemissao,
            StatusFuncionario = (StatusFuncionarioEnum)request.StatusFuncionario,
            VencimentoFerias = request.VencimentoFerias,

            Endereco = new Domain.Entities.Endereco()
            {
                Rua = endereco.Rua,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                Estado = (EstadosEnum)endereco.Estado,
                Pais = endereco.Pais
            }
        };

        return result;
    }
}
