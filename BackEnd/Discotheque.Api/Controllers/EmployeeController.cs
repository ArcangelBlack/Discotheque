using DomainModels.Model;
using DomainServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Discotheque.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ApiController
    {
        #region Fields

        private readonly IEmployeeService employeeService;

        #endregion

        #region Constructor

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        #endregion

        [HttpGet()]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var result = new List<AppEmployee>();

                var resultService = await this.employeeService.GetAll();
                var enumerable = resultService.ToList();
                if (enumerable.Any())
                {
                    result = enumerable;
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }

        [HttpGet()]
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await this.employeeService.GetById(id);

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
        public async Task<IHttpActionResult> Create([FromBody]AppEmployee vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            var dateTime = System.DateTime.Now;

            vM.BirthDate = dateTime;
            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;

            this.employeeService.Add(vM);
            //await this.employeeService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            var result = CreatedAtRoute("GetEmployee", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut()]
        public async Task<IHttpActionResult> Put(int id, [FromBody]AppEmployee vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.employeeService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                result.Address = vM.Address;
                result.UpdatedDate = System.DateTime.Now;

                this.employeeService.Update(result);
                //await this.employeeService.Commit();
            }

            //user = Mapper.Map<User, UserViewModel>(_userDb);


            return this.StatusCode(HttpStatusCode.BadRequest);
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await this.employeeService.GetById(id);

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

                this.employeeService.Delete(result);

                //await this.employeeService.Commit();


                return this.StatusCode(HttpStatusCode.BadRequest);
            }
        }
    }
}