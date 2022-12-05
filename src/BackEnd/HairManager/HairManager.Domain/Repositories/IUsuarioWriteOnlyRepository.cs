using HairManager.Domain.Entities;

namespace HairManager.Domain.Repositories;

public interface IUsuarioWriteOnlyRepository
{
    Task Adicionar(Usuario usuario);
}
