using Commom.Contracts;
using Commom.Infra.MongoDB.Units;
using Estoque.Domain.Contracts.Repositories;
using Estoque.Infra.Data.MongoDb.Repositories.Produtos;
using Estoque.Infra.Data.MongoDb.Repositories.Usuarios;
using Ninject;
using System.Configuration;

namespace Estoque.IOC.Repositories
{
    public class RegisterMongo : IRegisterRepository
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IRepositoryUsuario>().To<RepositoryUsuario>().WithConstructorArgument("customCollectionName", "");
            kernel.Bind<IRepositoryProduto>().To<RepositoryProduto>().WithConstructorArgument("customCollectionName", "");
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("mongoDBString", ConfigurationManager.ConnectionStrings["EstoqueMongoDb"].ConnectionString).WithConstructorArgument("dataBaseName", "estoquetest");
        }
    }
}
