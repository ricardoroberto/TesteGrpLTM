using Commom.Contracts;
using Estoque.Domain.Entities;
using System.Collections.Generic;

namespace Estoque.Domain.Contracts.Repositories
{
    public interface IRepositoryProduto : IRepository<int, Produto>
    {
        IEnumerable<Produto> GetIniciadoPorNome(string nome);
    }
}
