using System.Collections.Generic;

namespace GymLog.Data.Entities {
    public class Muscle {

        public Muscle() {
            Exercises = new List<Exercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
