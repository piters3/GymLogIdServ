﻿using GymLog.IdSrv.Config;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using Owin;
using System;
using System.Security.Cryptography.X509Certificates;

namespace GymLog.IdSrv {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.Map("/identity", idsrvApp => {
                idsrvApp.UseIdentityServer(new IdentityServerOptions {
                    SiteName = "Embedded IdentityServer",
                    SigningCertificate = LoadCertificate(),

                    Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(StandardScopes.All)
                });
            });
        }

        X509Certificate2 LoadCertificate() {
            return new X509Certificate2(
                string.Format(@"{0}\bin\identityServer\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }

    }
}