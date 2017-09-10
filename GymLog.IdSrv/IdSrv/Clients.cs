using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace GymLog.IdSrv.IdSrv {
    public static class Clients {
        public static IEnumerable<Client> Get() {
            return new[]
            {
                new Client
                {             
                    ClientName = "MVCClient_code",
                    ClientId = "MVCClient_code",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    Flow = Flows.Hybrid,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.OfflineAccess
                    },
                    RedirectUris = new List<string>
                    {
                        GymLogConstants.MVCClient
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        GymLogConstants.MVCClient
                    },
                    Enabled = true,
                },
                new Client
                {
                    ClientName = "API",
                    ClientId = "mvc_service",
                    Flow = Flows.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "GymLogAPI"
                    }
                }
            };
        }
    }
}