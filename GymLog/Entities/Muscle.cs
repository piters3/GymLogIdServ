using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymLog.Entities {
    public class Muscle {

        public Muscle() {
            Exercises = new List<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę mięśnia")]
        [Display(Name = "Nazwa mięnia")]
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}