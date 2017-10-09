using Commom.Api.OAuthServer;
using Commom.Domain.Contracts.UserValidate;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Estoque.Api.Startup))]

namespace Estoque.Api
{
    public enum DbEngineEnum
    {
        SqlServer,
        MongoDb
    }

    public class Startup
    {
        /// <summary>
        /// Modificando a linha abaixo, você modifica qual o SGDB utilizado.
        /// Foram criadas duas libraries. Uma para SQL Server e outra para MongoDB
        /// </summary>
        public static readonly DbEngineEnum DbEngine = DbEngineEnum.MongoDb;
        
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var userValidate = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserValidate)) as IUserValidate;
            var authProvider = new OAuthServerProvider(userValidate);
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = authProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
