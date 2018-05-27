using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using D.Models.Models;
using DiscothequeW.Services.Interfaces;
using DiscothequeW.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    public class UserController : Controller
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<User>();

            var resultService = await this.userService.GetAll();
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
            var result = await this.userService.GetSingle(id);

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
        public async Task<IActionResult> Create([FromBody]User vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            this.userService.Add(vM);
            await this.userService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetEmployee", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]User vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.userService.GetSingle(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                this.userService.Update(vM);
                await this.userService.Commit();
            }

            //user = Mapper.Map<User, UserViewModel>(_userDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.userService.GetSingle(id);

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

                this.userService.Delete(result);

                await this.userService.Commit();

                return new NoContentResult();
            }
        }
    }
}