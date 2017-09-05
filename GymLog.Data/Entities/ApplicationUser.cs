using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GymLog.Data.Entities {
    public class ApplicationUser : IdentityUser {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType) {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }

        public ApplicationUser() {
            Workouts = new List<Workout>();
            Daylogs = new List<Daylog>();
        }

        public virtual ICollection<Daylog> Daylogs { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
