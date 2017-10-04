using Commom.Contracts;
using Commom.Infra.SqlServer.Repositories;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Estoque.Infra.Data.SqlServer.Repositories.Produtos
{
    public class RepositoryProduto : Repository<int, Produto>, IRepositoryProduto
    {
        public RepositoryProduto(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Produto> GetIniciadoPorNome(string nome)
        {
            return this.GetAll().Where(n => n.Nome.StartsWith(nome));
        }
    }
}
