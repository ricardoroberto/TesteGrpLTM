using Commom.Domain.Contracts.UserValidate;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Commom.Api.OAuthServer
{
    public class OAuthServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserValidate _userValidate;

        public OAuthServerProvider(IUserValidate userValidate)
        {
            this._userValidate = userValidate;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            if (_userValidate.ValidateUser(context.UserName, context.Password))
            {
                foreach(var role in _userValidate.GetRoles(context.UserName))
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));

                identity.AddClaim(new Claim("username", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, _userValidate.GetName(context.UserName)));
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