using Commom.Contracts;
using Commom.Infra.MongoDB.Repositories;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Domain.Entities;
using System.Linq;

namespace Estoque.Infra.Data.MongoDb.Repositories.Usuarios
{
    public class RepositoryUsuario : Repository<string, Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(IUnitOfWork unitOfWork, string customCollectionName = null) : base(unitOfWork, customCollectionName)
        {
        }

        public Usuario GetByLogin(string usuario, string senha)
        {
            return this.GetAll().FirstOrDefault(f => f.Id == usuario && f.Senha==senha);
        }
    }
}
