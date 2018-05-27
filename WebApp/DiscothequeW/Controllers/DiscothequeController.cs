using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using D.Models.GoogleModels;
using D.Models.Models;
using DiscothequeW.Services.Interaces;
using DiscothequeW.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DiscothequeController : Controller
    {
        #region Fields

        private readonly IDiscothequeService discothequeService;

        #endregion

        #region Constructor

        public DiscothequeController(IDiscothequeService discothequeService)
        {
            this.discothequeService = discothequeService;
        }

        #endregion

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAvailables()
        {
            //API Key
            const string apiKey = "AIzaSyCzUGfbgbzOPERSArlTI8kAjphhsIFVGXU";

            //The custom search engine identifier
            const string searchEngineId = "012492674958042532303:q2ey6tmaaru";

            const string query = "Discotecas de Trujillo";

            var tmpList = new List<ItemModel>();

            var result = new GoogleSearch
            {
                Key = apiKey,
                CX = searchEngineId
            };
            result.SearchCompleted += (a, b) =>
            {
                tmpList = b.Response.Items;
            };
            result.Search(query);

            return Json(tmpList);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<Discotheque>();

            var resultService = await this.discothequeService.GetAll();
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
            var result = await this.discothequeService.GetSingle(id);

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
        public async Task<IActionResult> Create([FromBody]Discotheque vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            this.discothequeService.Add(vM);
            await this.discothequeService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetEmployee", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Discotheque vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.discothequeService.GetSingle(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                this.discothequeService.Update(vM);
                await this.discothequeService.Commit();
            }

            //user = Mapper.Map<User, UserViewModel>(_userDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.discothequeService.GetSingle(id);

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

                this.discothequeService.Delete(result);

                await this.discothequeService.Commit();

                return new NoContentResult();
            }
        }
    }
}