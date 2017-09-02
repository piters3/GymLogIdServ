using GymLog.Entities;
using GymLog.Infrastructure;
using GymLog.Models;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GymLog.Controllers {
    [RoutePrefix("api/equipments")]
    public class EquipmentsController : ApiController {

        private IGymLogRepository _repo;


        public EquipmentsController(IGymLogRepository repo) {
            _repo = repo;
        }


        [Route("", Name = "Equipments")]
        public IQueryable<EquipmentModel> Get() {
            var equipments = _repo.GetEquipments().Select(m =>
                new EquipmentModel() {
                    Id = m.Id,
                    Name = m.Name,
                });
            return equipments;
        }


        [ResponseType(typeof(EquipmentModel))]
        [Route("{id}", Name = "Equipment")]
        public IHttpActionResult Get(int id) {
            var equipment = _repo.GetEquipments().Select(m =>
                new MuscleModel() {
                    Id = m.Id,
                    Name = m.Name,
                }).SingleOrDefault(m => m.Id == id);
            if (equipment == null) {
                return NotFound();
            }
            return Ok(equipment);
        }


        [ResponseType(typeof(Equipment))]
        [Route("")]
        public IHttpActionResult Post(Equipment eq) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _repo.Insert(eq);
            _repo.SaveAll();
            return Ok(eq);
        }


        [ResponseType(typeof(void))]
        [Route("{id}")]
        public IHttpActionResult Put(int id, Equipment eq) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != eq.Id) {
                return BadRequest();
            }
            _repo.Update(eq);
            try {
                _repo.SaveAll();
            } catch (DbUpdateConcurrencyException) {
                if (!_repo.EquipmentExist(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return Ok(eq);
        }

        [ResponseType(typeof(Equipment))]
        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            Equipment eq = _repo.GetEquipment(id);
            if (eq == null) {
                return NotFound();
            }
            _repo.Delete(eq);
            _repo.SaveAll();
            return Ok(eq);
        }
    }
}
