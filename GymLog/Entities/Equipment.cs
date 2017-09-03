using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymLog.Entities {
    public class Equipment {

        public Equipment() {
            Exercises = new List<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę urządzenia")]
        [Display(Name = "Nazwa urządzenia")]
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}