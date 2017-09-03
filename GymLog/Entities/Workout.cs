using GymLog.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymLog.Entities {
    public class Workout {

        public Workout() {
            Daylogs = new HashSet<Daylog>();
            Exercises = new List<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public int Rest { get; set; }

        public virtual ICollection<Daylog> Daylogs { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}