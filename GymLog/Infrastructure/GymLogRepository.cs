using GymLog.Entities;
using System.Data.Entity;
using System.Linq;

namespace GymLog.Infrastructure {
    public class GymLogRepository : IGymLogRepository {

        private GymLogContext _ctx;

        public GymLogRepository(GymLogContext ctx) {
            _ctx = ctx;
        }

        public bool SaveAll() {
            return _ctx.SaveChanges() > 0;
        }

        public bool MuscleExist(int id) {
            return _ctx.Muscles.Count(m => m.Id == id) > 0;
        }

        public IQueryable<Muscle> GetMuscles() {
            return _ctx.Muscles;
        }

        public Muscle GetMuscle(int id) {
            return _ctx.Muscles.Where(m => m.Id == id).FirstOrDefault();
        }

        public void Insert(Muscle muscle) {
            _ctx.Muscles.Add(muscle);
        }

        public void Update(Muscle muscle) {
            _ctx.Entry(muscle).State = EntityState.Modified;
        }

        public void Delete(Muscle muscle) {
            _ctx.Muscles.Remove(muscle);
        }

        public bool EquipmentExist(int id) {
            return _ctx.Equipments.Count(e => e.Id == id) > 0;
        }

        public IQueryable<Equipment> GetEquipments() {
            return _ctx.Equipments;
        }

        public Equipment GetEquipment(int id) {
            return _ctx.Equipments.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Insert(Equipment eq) {
            _ctx.Equipments.Add(eq);
        }

        public void Update(Equipment eq) {
            _ctx.Entry(eq).State = EntityState.Modified;
        }

        public void Delete(Equipment eq) {
            _ctx.Equipments.Remove(eq);
        }
    }
}