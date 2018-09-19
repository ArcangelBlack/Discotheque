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
    public class UserController : ApiController
    {
        #region Fields

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        [HttpGet()]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = new List<AppUser>();

            var resultService = await this.userService.GetAll();
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
            var result = await this.userService.GetById(id);

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
        public async Task<IHttpActionResult> Create([FromBody]AppUser vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            var dateTime = System.DateTime.Now;

            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;

            this.userService.Add(vM);
            //await this.userService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            var result = CreatedAtRoute("GetUser", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut()]
        public async Task<IHttpActionResult> Put(int id, [FromBody]AppUser vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.userService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                result.Address = vM.Address;
                result.UpdatedDate = System.DateTime.Now;

                this.userService.Update(result);
                //await this.userService.Commit();
            }

            //user = Mapper.Map<User, UserViewModel>(_userDb);

            return this.StatusCode(HttpStatusCode.BadRequest);
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await this.userService.GetById(id);

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

                this.userService.Delete(result);

                //await this.userService.Commit();

                return this.StatusCode(HttpStatusCode.BadRequest);
            }
        }
    }
}