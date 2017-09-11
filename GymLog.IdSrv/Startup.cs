using GymLog.IdSrv.IdMgr;
using GymLog.IdSrv.IdSrv;
using IdentityManager.Configuration;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Security.Cryptography.X509Certificates;
using static IdentityManager.Constants;

namespace GymLog.IdSrv {
    public class Startup {
        public void Configuration(IAppBuilder app) {

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = "Cookies"
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

            app.Map("/admin", adminApp => {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureSimpleIdentityManagerService("GymlogDB");
                adminApp.UseIdentityManager(new IdentityManagerOptions() {
                    Factory = factory,
                    // SecurityConfiguration = new HostSecurityConfiguration {
                    //  SecurityConfiguration = new LocalhostSecurityConfiguration {
                    // HostAuthenticationType = "Cookies",
                    //AdminRoleName = "Admin",                  
                    //RoleClaimType = "role"
                    //RequireSsl = false
                    // }
                    SecurityConfiguration = new LocalhostSecurityConfiguration {
                        HostAuthenticationType = "Cookies",
                        AdditionalSignOutType = "oidc",
                        NameClaimType = ClaimTypes.Name,
                        RoleClaimType = ClaimTypes.Role,
                        AdminRoleName = "Admin" //default role name for IdentityManager
                    }
                });
            });
        }

        X509Certificate2 LoadCertificate() {
            return new X509Certificate2(
                string.Format(@"{0}\IdSrv\Certificate\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}