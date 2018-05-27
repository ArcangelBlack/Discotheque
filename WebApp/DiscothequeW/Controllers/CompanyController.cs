using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.Models.Models;
using DiscothequeW.Services.Interaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    public class CompanyController : Controller
    {
        #region Fields

        private readonly ICompanyService companyService;

        #endregion

        #region Constructor

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        #endregion

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<Company>();

            var resultService = await this.companyService.GetAll();
            var enumerable = resultService.ToList();
            if (enumerable.Any())
            {
                result = enumerable;
            }
            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.companyService.GetSingle(id);

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
        public async Task<IActionResult> Create([FromBody]Company vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            this.companyService.Add(vM);
            await this.companyService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetEmployee", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Company vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.companyService.GetSingle(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                this.companyService.Update(vM);
                await this.companyService.Commit();
            }

            //user = Mapper.Map<User, UserViewModel>(_userDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.companyService.GetSingle(id);

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

                companyService.Delete(result);

                await companyService.Commit();

                return new NoContentResult();
            }
        }
    }
}