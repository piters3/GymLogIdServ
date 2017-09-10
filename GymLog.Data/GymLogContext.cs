using GymLog.Data.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymLog.Data
{
    public class GymLogContext : IdentityDbContext<User, Role, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> {
        public GymLogContext()
            : base("GymlogDB") {
        }

        public DbSet<Daylog> Daylogs { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        public static GymLogContext Create() {
            return new GymLogContext();
        }
    }
}
