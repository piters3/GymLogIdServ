﻿using System;
using System.Collections.Generic;

namespace GymLog.Data.Entities {
    public class Daylog {

        public Daylog() {
            Workouts = new List<Workout>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
