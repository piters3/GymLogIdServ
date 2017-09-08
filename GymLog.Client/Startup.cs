using GymLog.Client.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols;
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

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;

            //JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                ClientId = "MVCClient",
                Authority = GymLogConstants.IdSrv,
                RedirectUri = GymLogConstants.MVCClient,
                Scope = "openid profile roles",
                ResponseType = "id_token token", //jak dam token jest 403
                PostLogoutRedirectUri = GymLogConstants.MVCClient,
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //UseTokenLifetime = false,

                Notifications = new OpenIdConnectAuthenticationNotifications {
                    SecurityTokenValidated = notification => {

                        var identity = notification.AuthenticationTicket.Identity;
                        identity.AddClaim(new Claim("id_token", notification.ProtocolMessage.IdToken));
                        identity.AddClaim(new Claim("access_token", notification.ProtocolMessage.AccessToken));

                        notification.AuthenticationTicket = new AuthenticationTicket(identity, notification.AuthenticationTicket.Properties);


                        return Task.FromResult(0);
                    },
                    RedirectToIdentityProvider = notification => {
                        if (notification.ProtocolMessage.RequestType != OpenIdConnectRequestType.LogoutRequest) {
                            return Task.FromResult(0);
                        }

                        notification.ProtocolMessage.IdTokenHint = notification.OwinContext.Authentication.User.FindFirst("id_token").Value;
                        return Task.FromResult(0);
                    }
                }




             /*   Notifications = new OpenIdConnectAuthenticationNotifications {
                    SecurityTokenValidated = async n =>
                    {
                        var nid = new ClaimsIdentity(
                            n.AuthenticationTicket.Identity.AuthenticationType,
                            ClaimTypes.GivenName,
                            ClaimTypes.Role);
                            */
                        // get userinfo data
                    /*    var userInfoClient = new UserInfoClient(
                            new Uri(n.Options.Authority + "/connect/userinfo"),
                            n.ProtocolMessage.AccessToken);

                        var userInfo = await userInfoClient.GetAsync();
                        userInfo.Claims.ToList().ForEach(ui => nid.AddClaim(new Claim(ui.Item1, ui.Item2)));*/

                        // keep the id_token for logout
                    /*    nid.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));

                        // add access token for sample API
                        nid.AddClaim(new Claim("access_token", n.ProtocolMessage.AccessToken));

                        // keep track of access token expiration
                        nid.AddClaim(new Claim("expires_at", DateTimeOffset.Now.AddSeconds(int.Parse(n.ProtocolMessage.ExpiresIn)).ToString()));

                        // add some other app specific claim
                        nid.AddClaim(new Claim("app_specific", "some data"));

                        n.AuthenticationTicket = new AuthenticationTicket(
                            nid,
                            n.AuthenticationTicket.Properties);*/

                 /*   },

                    RedirectToIdentityProvider = n =>
                    {
                        if (n.ProtocolMessage.RequestType == OpenIdConnectRequestType.LogoutRequest) {
                            var idTokenHint = n.OwinContext.Authentication.User.FindFirst("id_token");

                            if (idTokenHint != null) {
                                n.ProtocolMessage.IdTokenHint = idTokenHint.Value;
                            }
                        }

                        return Task.FromResult(0);
                    }
                }*/
                
            });


        }
    }
}