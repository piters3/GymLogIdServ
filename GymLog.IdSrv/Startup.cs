using GymLog.IdSrv.IdMgr;
using GymLog.IdSrv.IdSrv;
using IdentityManager.Configuration;
using IdentityServer3.Core.Configuration;
using Owin;
using System;
using System.Security.Cryptography.X509Certificates;


namespace GymLog.IdSrv {
    public class Startup {
        public void Configuration(IAppBuilder app) {

            app.Map("/admin", adminApp => {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureSimpleIdentityManagerService("GymlogDB");

                adminApp.UseIdentityManager(new IdentityManagerOptions() {
                    Factory = factory
                });
            });

            app.Map("/identity", core => {
                var idSvrFactory = Factory.Configure();
                idSvrFactory.ConfigureUserService("GymlogDB");

                var options = new IdentityServerOptions {
                    SiteName = "IdentityServer3",
                    SigningCertificate = LoadCertificate(),
                    Factory = idSvrFactory
                };

                core.UseIdentityServer(options);
            });
        }

        X509Certificate2 LoadCertificate() {
            return new X509Certificate2(
                string.Format(@"{0}\IdSrv\Certificate\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }

    }
}