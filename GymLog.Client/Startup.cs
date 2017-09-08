using GymLog.Client.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Thinktecture.IdentityModel.Clients;

namespace GymLog.Client {

    public class Startup {

        public void Configuration(IAppBuilder app) {

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Email;
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseResourceAuthorization(new AuthorizationManager());

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                ClientId = "MVCClient_code",
                Authority = GymLogConstants.IdSrv,
                RedirectUri = GymLogConstants.MVCClient,
                ResponseType = "code id_token", //jak dam token jest 403
                Scope = "openid profile offline_access",         
                PostLogoutRedirectUri = GymLogConstants.MVCClient,
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                Notifications = new OpenIdConnectAuthenticationNotifications {
                    AuthorizationCodeReceived = async notification => {
                        var requestResponse = await OidcClient.CallTokenEndpointAsync(
                            new Uri(GymLogConstants.IdSrvToken),
                            new Uri(GymLogConstants.MVCClient),
                            notification.Code,
                            "MVCClient_code",
                            "secret");

                        var identity = notification.AuthenticationTicket.Identity;

                        identity.AddClaim(new Claim("access_token", requestResponse.AccessToken));
                        identity.AddClaim(new Claim("id_token", requestResponse.IdentityToken));
                        identity.AddClaim(new Claim("refresh_token", requestResponse.RefreshToken));

                        notification.AuthenticationTicket = new AuthenticationTicket(
                            identity, notification.AuthenticationTicket.Properties);
                    },
                    RedirectToIdentityProvider = notification => {
                        if (notification.ProtocolMessage.RequestType != OpenIdConnectRequestType.LogoutRequest) {
                            return Task.FromResult(0);
                        }
                        notification.ProtocolMessage.IdTokenHint = notification.OwinContext.Authentication.User.FindFirst("id_token").Value;
                        return Task.FromResult(0);
                    }
                }             
            });
        }
    }
}