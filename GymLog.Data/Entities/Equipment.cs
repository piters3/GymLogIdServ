using System.Collections.Generic;

namespace GymLog.Data.Entities {
    public class Equipment {

        public Equipment() {
            Exercises = new List<Exercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
