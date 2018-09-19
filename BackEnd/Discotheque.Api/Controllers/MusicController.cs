using DomainModels.Model;
using DomainServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Discotheque.Api.Controllers
{
    [Route("api/[controller]")]
    public class MusicController : ApiController
    {
        #region Fields

        private readonly IMusicService musicService;

        #endregion

        #region Constructor

        public MusicController(IMusicService musicService)
        {
            this.musicService = musicService;
        }

        #endregion

        [HttpGet()]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = new List<AppMusic>();

            var resultService = await this.musicService.GetAll();
            var enumerable = resultService.ToList();
            if (enumerable.Any())
            {
                result = enumerable;
            }
            return Json(result);
        }

        [HttpGet()]
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await this.musicService.GetById(id);

            if (result != null)
            {
                //var _userVM = Mapper.Map<User, UserViewModel>(_user);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]AppMusic vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            this.musicService.Add(vM);
            //await this.musicService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            var result = CreatedAtRoute("GetEmployee", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut()]
        public async Task<IHttpActionResult> Put(int id, [FromBody]AppMusic vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.musicService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                this.musicService.Update(vM);
                //await this.musicService.Commit();
            }

            //user = Mapper.Map<User, UserViewModel>(_userDb);


            return this.StatusCode(HttpStatusCode.BadRequest);
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await this.musicService.GetById(id);

            if (result == null)
            {

                return this.StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                //IEnumerable<Attendee> _attendees = _attendeeRepository.FindBy(a => a.UserId == id);
                //IEnumerable<Schedule> _schedules = _scheduleRepository.FindBy(s => s.CreatorId == id);

                //foreach (var attendee in _attendees)
                //{
                //    _attendeeRepository.Delete(attendee);
                //}

                //foreach (var schedule in _schedules)
                //{
                //    _attendeeRepository.DeleteWhere(a => a.ScheduleId == schedule.Id);
                //    _scheduleRepository.Delete(schedule);
                //}

                this.musicService.Delete(result);

                //await this.musicService.Commit();


                return this.StatusCode(HttpStatusCode.BadRequest);
            }
        }
    }
}