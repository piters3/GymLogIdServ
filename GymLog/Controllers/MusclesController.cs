using GymLog.Entities;
using GymLog.Infrastructure;
using GymLog.Models;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace GymLog.Controllers {
    [RoutePrefix("api/muscles")]
    public class MusclesController : ApiController {

        private IGymLogRepository _repo;

        public MusclesController(IGymLogRepository repo) {
            _repo = repo;
        }


        [Route("", Name = "Muscles")]
        public IQueryable<MuscleModel> Get() {
            var muscles = _repo.GetMuscles().Select(m =>
                new MuscleModel() {
                    Id = m.Id,
                    Name = m.Name,
                });
            return muscles;
        }


        [ResponseType(typeof(MuscleModel))]
        [Route("{id}", Name = "Muscle")]
        public IHttpActionResult Get(int id) {
            var muscle = _repo.GetMuscles().Select(m =>
                new MuscleModel() {
                    Id = m.Id,
                    Name = m.Name,
                }).SingleOrDefault(m => m.Id == id);
            if (muscle == null) {
                return NotFound();
            }
            return Ok(muscle);
        }


        [ResponseType(typeof(Muscle))]
        [Route("")]
        public IHttpActionResult Post(Muscle muscle) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _repo.Insert(muscle);
            _repo.SaveAll();
            return Ok(muscle);
        }


        [ResponseType(typeof(void))]
        [Route("{id}")]
        public IHttpActionResult Put(int id, Muscle muscle) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != muscle.Id) {
                return BadRequest();
            }
            _repo.Update(muscle);
            try {
                _repo.SaveAll();
            } catch (DbUpdateConcurrencyException) {
                if (!_repo.MuscleExist(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return Ok(muscle);
        }


        [ResponseType(typeof(Muscle))]
        [Route("{id}")]
        public IHttpActionResult Delete(int id) {
            Muscle muscle = _repo.GetMuscle(id);
            if (muscle == null) {
                return NotFound();
            }
            _repo.Delete(muscle);
            _repo.SaveAll();
            return Ok(muscle);
        }
    }
}
