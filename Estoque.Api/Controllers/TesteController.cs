using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Estoque.Api.Controllers
{
    public class TesteController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/teste/pode")]
        public IHttpActionResult Get()
        {
            return Ok("Ok! " + DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet]
        [Route("api/teste/npode")]
        public IHttpActionResult GetProdutos()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Oi, " + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("aip/teste/npodeadmin")]
        public IHttpActionResult GetProdutosNovos()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(s => s.Value);

            return Ok("Oi, " + identity.Name + " roles: " + string.Join(",", roles));
        }
    }
}
