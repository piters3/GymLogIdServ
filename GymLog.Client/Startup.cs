using GymLog.Client.Helpers;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace GymLog.Client {

    public class Startup {

        public void Configuration(IAppBuilder app) {

            //AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;
            //JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            //app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = "Cookies"
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                ClientId = "MVCClient",
                Authority = GymLogConstants.IdSrv,
                RedirectUri = GymLogConstants.MVCClient,
                Scope = "openid profile roles",
                ResponseType = "id_token",
                SignInAsAuthenticationType = "Cookies",
                //UseTokenLifetime = false,

                /*Notifications = new OpenIdConnectAuthenticationNotifications {
                    SecurityTokenValidated = n => {
                        var id = n.AuthenticationTicket.Identity;

                        // we want to keep first name, last name, subject and roles
                        var givenName = id.FindFirst(ClaimTypes.GivenName);
                        var email = id.FindFirst(ClaimTypes.Email);
                        var roles = id.FindAll(ClaimTypes.Role);

                        // create new identity and set name and role claim type
                        var nid = new ClaimsIdentity(
                            id.AuthenticationType,
                            ClaimTypes.GivenName,
                            ClaimTypes.Role);

                        nid.AddClaim(givenName);
                        nid.AddClaim(email);
                        nid.AddClaims(roles);

                        // add some other app specific claim
                        nid.AddClaim(new Claim("app_specific", "some data"));

                        n.AuthenticationTicket = new AuthenticationTicket(
                            nid,
                            n.AuthenticationTicket.Properties);

                        return Task.FromResult(0);
                    }
                }*/
            });


        }
    }
}