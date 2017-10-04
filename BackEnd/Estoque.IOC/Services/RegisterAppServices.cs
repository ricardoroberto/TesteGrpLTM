using Commom.Domain.Contracts.UserValidate;
using Estoque.Domain.Contracts.AppServices;
using Estoque.Service;
using Ninject;

namespace Estoque.IOC.Services
{
    public class RegisterAppServices
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IAppServiceLogin>().To<AppServiceLogin>();
            kernel.Bind<IAppServiceProduto>().To<AppServiceProduto>();
            kernel.Bind<IUserValidate>().To<UserServiceValidate>();
            
        }
    }
}
