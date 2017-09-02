using GymLog.Entities;
using GymLog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GymLog.Infrastructure {
    public class GymLogContext : IdentityDbContext<ApplicationUser> {
        public GymLogContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public static GymLogContext Create() {
            return new GymLogContext();
        }
    }
}