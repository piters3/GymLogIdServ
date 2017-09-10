using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdSvr3 = IdentityServer3.Core;

namespace GymLog.Data.Entities {

    public class User : IdentityUser {
        public User() {
            Workouts = new List<Workout>();
            Daylogs = new List<Daylog>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Daylog> Daylogs { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }


    }

    public class Role : IdentityRole { }

    //public class Context : IdentityDbContext<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> {
    //    public Context(string connString)
    //        : base(connString) {
    //    }
    //}

    public class UserStore : UserStore<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> {
        public UserStore(GymLogContext ctx)
            : base(ctx) {
        }
    }

    public class UserManager : UserManager<User, string> {
        public UserManager(UserStore store)
            : base(store) {
            ClaimsIdentityFactory = new ClaimsFactory();
        }
    }

    public class ClaimsFactory : ClaimsIdentityFactory<User, string> {
        public ClaimsFactory() {
            UserIdClaimType = IdSvr3.Constants.ClaimTypes.Subject;
            UserNameClaimType = IdSvr3.Constants.ClaimTypes.PreferredUserName;
            RoleClaimType = IdSvr3.Constants.ClaimTypes.Role;
        }

        public override async System.Threading.Tasks.Task<ClaimsIdentity> CreateAsync(UserManager<User, string> manager, User user, string authenticationType) {
            var ci = await base.CreateAsync(manager, user, authenticationType);
            if (!String.IsNullOrWhiteSpace(user.FirstName)) {
                ci.AddClaim(new Claim("given_name", user.FirstName));
            }
            if (!String.IsNullOrWhiteSpace(user.LastName)) {
                ci.AddClaim(new Claim("family_name", user.LastName));
            }
            return ci;
        }
    }

    public class RoleStore : RoleStore<Role> {
        public RoleStore(GymLogContext ctx)
            : base(ctx) {
        }
    }

    public class RoleManager : RoleManager<Role> {
        public RoleManager(RoleStore store)
            : base(store) {
        }
    }

}