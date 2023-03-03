namespace HairManager.Domain.Repositories.Shared;
public interface IEnderecoWriteOnlyRepository
{
    Task Adicionar(Entities.Endereco endereco);
}
