using Commom.Contracts;
using Commom.Infra.SqlServer.Units;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Infra.Data.Sql.Context;
using Estoque.Infra.Data.SqlServer.Repositories.Produtos;
using Estoque.Infra.Data.SqlServer.Repositories.Usuarios;
using Ninject;
using System.Data.Entity;

namespace Estoque.IOC.Repositories
{
    public class RegisterSqlServer : IRegisterRepository
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IRepositoryUsuario>().To<RepositoryUsuario>();
            kernel.Bind<IRepositoryProduto>().To<RepositoryProduto>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<DbContext>().To<EstoqueContext>();
        }
    }
}
