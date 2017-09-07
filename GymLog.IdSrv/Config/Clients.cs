using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace GymLog.IdSrv.Config {
    public static class Clients {
        public static IEnumerable<Client> Get() {
            return new[]
            {
            new Client
            {
                ClientId = "socialnetwork",
                ClientSecrets = new List<Secret>
                {
                    new Secret("secret".Sha256())
                },
                ClientName = "SocialNetwork",
                Flow = Flows.ResourceOwner,
                RedirectUris = new List<string>
                {
                    "https://localhost:44319/"
                },

                AllowAccessToAllScopes = true,
                Enabled = true,
            }
        };
        }
    }
}