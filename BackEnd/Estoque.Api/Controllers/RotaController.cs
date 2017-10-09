using Estoque.Domain.Contracts.AppServices;
using System.Web.Http;

namespace Estoque.Api.Controllers
{
    public class RotaController : ApiController
    {
        private IAppServiceLogin _serviceLogin;

        public RotaController()
        {
            this._serviceLogin = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAppServiceLogin)) as IAppServiceLogin;
        }
    }
}
