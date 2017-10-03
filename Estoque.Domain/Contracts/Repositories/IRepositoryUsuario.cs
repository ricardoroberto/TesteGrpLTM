using Commom.Contracts;
using Estoque.Domain.Entities;

namespace Estoque.Domain.Contracts.Repositories
{
    public interface IRepositoryUsuario : IRepository<string, Usuario>
    {
        Usuario GetByLogin(string usuario, string senha);
    }
}
