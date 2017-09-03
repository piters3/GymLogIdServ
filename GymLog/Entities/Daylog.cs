using GymLog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymLog.Entities {
    public class Daylog {

        public Daylog() {
            Workouts = new HashSet<Workout>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}