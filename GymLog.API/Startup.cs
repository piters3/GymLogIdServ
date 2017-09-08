using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(GymLog.API.Startup))]

namespace GymLog.API {
    public class Startup {
        public void Configuration(IAppBuilder app) {

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {
                Authority = GymLogConstants.IdSrv,
                RequiredScopes = new[] { "GymLogApi" }
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}
