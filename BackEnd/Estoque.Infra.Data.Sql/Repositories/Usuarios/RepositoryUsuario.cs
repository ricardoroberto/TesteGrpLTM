using Commom.Contracts;
using Commom.Infra.SqlServer.Repositories;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Domain.Entities;
using System.Linq;

namespace Estoque.Infra.Data.SqlServer.Repositories.Usuarios
{
    public class RepositoryUsuario : Repository<string, Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Usuario GetByLogin(string usuario, string senha)
        {
            return this.GetAll().FirstOrDefault(f => f.Id == usuario && f.Senha == senha);
        }
    }
}
