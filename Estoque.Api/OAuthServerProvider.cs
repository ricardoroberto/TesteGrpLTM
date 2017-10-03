using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Estoque.Api
{
    public class OAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Administrador"));
                context.Validated(identity);
            }
            else if (context.UserName == "ricardoroberto" && context.Password == "lala123")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "ricardoroberto"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Ricardo Gonçalves"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_credential", "Usuário/senha unválidos.");
                return;
            }
        }
    }
}