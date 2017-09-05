namespace GymLog.Data.Migrations {
    using GymLog.Data;
    using GymLog.Data.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GymLog.Data.GymLogContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "Library.Models.ApplicationDbContext";
        }

        protected override void Seed(GymLogContext context) {

            /* context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Daylogs]");
             context.Database.ExecuteSqlCommand("TRUNCATE TABLE [DaylogWorkouts]");
             context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Equipments]");
             context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Exercises]");
             context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Muscles]");
             context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Workouts]");*/

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



            var muscles = new List<Muscle>{
                new Muscle() { Name = "Triceps" },
                new Muscle() { Name = "Klatka piersiowa" },
                new Muscle() { Name = "Barki" },
                new Muscle() { Name = "Biceps" },
                new Muscle() { Name = "Brzuch" },
                new Muscle() { Name = "Plecy" },
                new Muscle() { Name = "Przedramiê" },
                new Muscle() { Name = "Udo" },
                new Muscle() { Name = "Poœladki" },
                new Muscle() { Name = "£ydki" },
                new Muscle() { Name = "Cardio" }
                };
            muscles.ForEach(m => context.Muscles.AddOrUpdate(x => x.Name, m));
            context.SaveChanges();



            var equipments = new List<Equipment> {
                new Equipment() { Name = "Hantel" },
                new Equipment() { Name = "£awka prosta" },
                new Equipment() { Name = "Wyci¹g" },
                new Equipment() { Name = "Suwnica" },
                new Equipment() { Name = "Sztanga prosta" },
                new Equipment() { Name = "Sztanga giêta" },
                new Equipment() { Name = "Dr¹¿ek" }
                };
            equipments.ForEach(m => context.Equipments.AddOrUpdate(x => x.Name, m));
            context.SaveChanges();



            var exercises = new List<Exercise> {
                new Exercise() { Name = "Wyciskanie sztangi le¿¹c", Description = "Bla bla bla", Muscle = muscles.Single(m=>m.Name=="Klatka piersiowa"), Equipment = equipments.Single(m=>m.Name=="£awka prosta")},
                new Exercise() { Name = "Przysiady", Description = "Bla bla bla", Muscle = muscles.Single(m=>m.Name=="Udo"), Equipment = equipments.Single(m=>m.Name=="Suwnica")},
                new Exercise() { Name = "Podci¹ganie", Description = "Bla bla bla", Muscle = muscles.Single(m=>m.Name=="Plecy"), Equipment = equipments.Single(m=>m.Name=="Dr¹¿ek")},
                };
            exercises.ForEach(m => context.Exercises.AddOrUpdate(x => x.Name, m));
            context.SaveChanges();



            var workouts = new List<Workout> {
                new Workout(){ Id = 1, Sets = 1, Reps = 8, Rest = 90, UserId = context.Users.FirstOrDefault().Id, Exercise= exercises.Single(m=>m.Name=="Wyciskanie sztangi le¿¹c") },
                new Workout(){ Id = 2, Sets = 2, Reps = 12, Rest = 90, UserId = context.Users.FirstOrDefault().Id, Exercise= exercises.Single(m=>m.Name=="Przysiady") },
                new Workout(){ Id = 3, Sets = 3, Reps = 14, Rest = 90, UserId = context.Users.FirstOrDefault().Id, Exercise= exercises.Single(m=>m.Name=="Wyciskanie sztangi le¿¹c") },
                new Workout(){ Id = 4, Sets = 4, Reps = 16, Rest = 90, UserId = context.Users.FirstOrDefault().Id, Exercise= exercises.Single(m=>m.Name=="Podci¹ganie") },
                new Workout(){ Id = 5, Sets = 5, Reps = 18, Rest = 90, UserId = context.Users.FirstOrDefault().Id, Exercise= exercises.Single(m=>m.Name=="Wyciskanie sztangi le¿¹c") },
                };
            workouts.ForEach(m => context.Workouts.AddOrUpdate(x => x.Id, m));
            context.SaveChanges();


            var daylogs = new List<Daylog> {
                new Daylog(){Id = 1, Date = DateTime.Now, UserId = context.Users.FirstOrDefault().Id, Workouts = new List<Workout>() },
                new Daylog(){Id = 2, Date = DateTime.Now, UserId = context.Users.FirstOrDefault().Id, Workouts = new List<Workout>() }
            };
            daylogs.ForEach(s => context.Daylogs.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();


            //for(var i=0;i<daylogs.Count; i++) {
            //    AddOrUpdateDayLog(context, context.Workouts.ToList()[i].Id, context.Daylogs.ToList()[i].Id);
            //}

            var workoutList = context.Workouts.ToList();
            var daylogList = context.Daylogs.ToList();

            AddOrUpdateDayLog(context, workoutList[0].Id, daylogList[0].Id);
            AddOrUpdateDayLog(context, workoutList[1].Id, daylogList[0].Id);
            AddOrUpdateDayLog(context, workoutList[2].Id, daylogList[0].Id);
            AddOrUpdateDayLog(context, workoutList[3].Id, daylogList[0].Id);
            AddOrUpdateDayLog(context, workoutList[4].Id, daylogList[0].Id);
            AddOrUpdateDayLog(context, workoutList[1].Id, daylogList[1].Id);
            AddOrUpdateDayLog(context, workoutList[2].Id, daylogList[1].Id);
            AddOrUpdateDayLog(context, workoutList[3].Id, daylogList[1].Id);

            context.SaveChanges();


        }

        void AddOrUpdateDayLog(GymLogContext context, int workoutId, int daylogId) {
            var crs = context.Workouts.SingleOrDefault(c => c.Id == workoutId);
            var inst = crs.Daylogs.SingleOrDefault(i => i.Id == daylogId);
            if (inst == null)
                crs.Daylogs.Add(context.Daylogs.Single(i => i.Id == daylogId));
        }

    }
}
