using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.Models.Models;
using DiscothequeW.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = new List<Employee>();

                var resultService = await this.employeeService.GetAll();
                var enumerable = resultService.ToList();
                if (enumerable.Any())
                {
                    result = enumerable;
                }
                return Json(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.employeeService.GetSingle(id);

            if (result != null)
            {
                //var _userVM = Mapper.Map<User, UserViewModel>(_user);
                return new OkObjectResult(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Employee vM)
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
            await this.employeeService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetEmployee", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Employee vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.employeeService.GetSingle(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                result.Address = vM.Address;
                result.UpdatedDate = System.DateTime.Now;

                this.employeeService.Update(result);
                await this.employeeService.Commit();
            }

            //user = Mapper.Map<User, UserViewModel>(_userDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.employeeService.GetSingle(id);

            if (result == null)
            {
                return new NotFoundResult();
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

                await this.employeeService.Commit();

                return new NoContentResult();
            }
        }
    }
}