using GymLog.IdSrv.Config;
using IdentityServer3.Core.Configuration;
using Owin;
using System;
using System.Security.Cryptography.X509Certificates;

namespace GymLog.IdSrv {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.Map("/identity", idsrvApp => {
                idsrvApp.UseIdentityServer(new IdentityServerOptions {
                    SiteName = "IdentityServer",
                    SigningCertificate = LoadCertificate(),
                    //IssuerUri = GymLogConstants.IdSrv,

                    Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get())
                });
            });
        }

        X509Certificate2 LoadCertificate() {
            return new X509Certificate2(
                string.Format(@"{0}\bin\identityServer\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }

    }
}