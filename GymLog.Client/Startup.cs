﻿using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace GymLog.Client {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = "Cookies"
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                Authority = "https://localhost:44321/identity",
                ClientId = "mvc",
                RedirectUri = "https://localhost:44356/",
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies"
            });
        }
    }
}