﻿using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace GymLog.IdSrv.IdSrv {
    public static class Scopes {
        public static IEnumerable<Scope> Get() {
            var scopes = new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Enabled = true,
                    Name = "roles",
                    Type=ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                },
                new Scope
                {
                    Enabled = true,
                    DisplayName = "GymLog API",
                    Name = "GymLogApi",
                    Description = "Access to a GymLog API",
                    Type = ScopeType.Resource
                }
            };

            //scopes.AddRange(StandardScopes.All);

            return scopes;
        }
    }
}