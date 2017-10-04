using Commom.Contracts;
using Commom.Infra.MongoDB.Repositories;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Estoque.Infra.Data.MongoDb.Repositories.Produtos
{
    public class RepositoryProduto : Repository<int, Produto>, IRepositoryProduto
    {
        public RepositoryProduto(IUnitOfWork unitOfWork, string customCollectionName = null) : base(unitOfWork, customCollectionName)
        {
        }

        public IEnumerable<Produto> GetIniciadoPorNome(string nome)
        {
            return this.GetAll().Where(n => n.Nome.StartsWith(nome));
        }
    }
}
