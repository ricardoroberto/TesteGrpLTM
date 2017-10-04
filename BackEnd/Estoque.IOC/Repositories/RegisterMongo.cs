using Commom.Contracts;
using Commom.Infra.MongoDB.Units;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Infra.Data.MongoDb.Repositories.Produtos;
using Estoque.Infra.Data.MongoDb.Repositories.Usuarios;
using Ninject;

namespace Estoque.IOC.Repositories
{
    public class RegisterMongo : IRegisterRepository
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IRepositoryUsuario>().To<RepositoryUsuario>();
            kernel.Bind<IRepositoryProduto>().To<RepositoryProduto>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
