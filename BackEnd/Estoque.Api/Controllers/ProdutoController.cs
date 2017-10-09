using Estoque.Domain.Contracts.AppServices;
using System.Linq;
using System.Web.Http;

namespace Estoque.Api.Controllers
{
    public class ProdutoController : ApiController
    {
        private readonly IAppServiceProduto _serviceProduto;
        //public ProdutoController(IAppServiceProduto serviceProduto)
        //{

        //    this._serviceProduto = serviceProduto;
        //}

        public ProdutoController()
        {
            this._serviceProduto = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IAppServiceProduto)) as IAppServiceProduto;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/produto/lista")]
        public IHttpActionResult GetProdutos()
        {
            var listaCompleta = _serviceProduto.Listar(null);

            if (listaCompleta == null || listaCompleta.Count()==0) return NotFound();

            return Ok(listaCompleta);
        }
    }
}
