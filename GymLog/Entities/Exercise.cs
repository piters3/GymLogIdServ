using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymLog.Entities {
    public class Exercise {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę ćwiczenia")]
        [Display(Name = "Nazwa ćwiczenia")]
        public string Name { get; set; }

        [Display(Name = "Opis ćwiczenia")]
        public string Description { get; set; }

        [Required]
        public int MuscleId { get; set; }
        [ForeignKey("MuscleId")]
        [Display(Name = "Mięsień")]
        public virtual Muscle Muscle { get; set; }

        [Required]
        public int EquipmentId { get; set; }
        [ForeignKey("EquipmentId")]
        [Display(Name = "Urządzenie")]
        public virtual Equipment Equipment { get; set; }
    }
}