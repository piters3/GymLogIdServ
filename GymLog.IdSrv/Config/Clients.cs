using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace GymLog.IdSrv.Config {
    public static class Clients {
        public static IEnumerable<Client> Get() {
            return new[]
            {
            new Client
            {
                Enabled = true,
                ClientName = "MVC Client",
                ClientId = "MVCClient",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    GymLogConstants.MVCClient
                },

                AllowAccessToAllScopes = true
            },
            //new Client
            //{
            //    ClientName = "MVC Client (service communication)",
            //    ClientId = "mvc_service",
            //    Flow = Flows.ClientCredentials,

            //    ClientSecrets = new List<Secret>
            //    {
            //        new Secret("secret".Sha256())
            //    },
            //    AllowedScopes = new List<string>
            //    {
            //        "GymLogAPI"
            //    }
            //}
        };
        }
    }
}