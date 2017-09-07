using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace GymLog.IdSrv.Config {
    public static class Users {
        public static List<InMemoryUser> Get() {
            return new List<InMemoryUser>
            {
            new InMemoryUser
            {
                Username = "bob",
                Password = "password",
                Subject = "bob",

                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Smith")
                }
            }
        };
        }
    }
}