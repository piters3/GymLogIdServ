using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;


namespace GymLog.IdSrv.Config {
    public static class Users {
        public static List<InMemoryUser> Get() {
            return new List<InMemoryUser>
            {
            new InMemoryUser
            {
                Username = "bob",
                Password = "bob",
                Subject = "1",

                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Bob"),
                    new Claim(Constants.ClaimTypes.Email, "Smith@qwe.com"),
                    new Claim(Constants.ClaimTypes.Role, "WebReadUser"),
                    //new Claim(Constants.ClaimTypes.Role, "WebWriteUser")
                }
            }
        };
        }
    }
}