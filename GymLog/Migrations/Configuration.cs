namespace GymLog.Migrations {
    using GymLog.Entities;
    using GymLog.Infrastructure;
    using GymLog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymLogContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "Library.Models.ApplicationDbContext";
        }

        protected override void Seed(GymLogContext context) {

            if (!context.Roles.Any(r => r.Name == "Admin")) {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "administrator")) {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "administrator" };

                manager.Create(user, "password!");
                manager.AddToRole(user.Id, "Admin");
            }

            context.Muscles.AddOrUpdate(x => x.Id,
                new Muscle() { Id = 1, Name = "Triceps" },
                new Muscle() { Id = 2, Name = "Klatka piersiowa" },
                new Muscle() { Id = 3, Name = "Barki" },
                new Muscle() { Id = 4, Name = "Biceps" },
                new Muscle() { Id = 5, Name = "Brzuch" },
                new Muscle() { Id = 6, Name = "Plecy" },
                new Muscle() { Id = 7, Name = "Przedramiê" },
                new Muscle() { Id = 8, Name = "Udo" },
                new Muscle() { Id = 9, Name = "Poœladki" },
                new Muscle() { Id = 10, Name = "£ydki" },
                new Muscle() { Id = 12, Name = "Cardio" }
                );
            context.Equipments.AddOrUpdate(x => x.Id,
                new Equipment() { Id = 1, Name = "Hantel" },
                new Equipment() { Id = 2, Name = "£awka prosta" },
                new Equipment() { Id = 3, Name = "Wyci¹g" },
                new Equipment() { Id = 4, Name = "Suwnica" },
                new Equipment() { Id = 5, Name = "Sztanga prosta" },
                new Equipment() { Id = 6, Name = "Sztanga giêta" }
                );
            context.Exercises.AddOrUpdate(x => x.Id,
                new Exercise() { Id = 1, Name = "Wyciskanie sztangi le¿¹c", Description = "Bla bla bla", EquipmentId = 1, MuscleId = 1 },
                new Exercise() { Id = 1, Name = "Przysiady", Description = "Bla bla bla", EquipmentId = 2, MuscleId = 3 },
                new Exercise() { Id = 1, Name = "Podci¹ganie", Description = "Bla bla bla", EquipmentId = 3, MuscleId = 3 }
                );
        }

    }
}
