using System.Collections.Generic;

namespace GymLog.API.Models {
    public class ExerciseModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Muscle { get; set; }
        public string Equipment { get; set; }
        //public IEnumerable<MuscleModel> Muscles { get; set; }
        //public IEnumerable<EquipmentModel> Equipments { get; set; }
    }
}