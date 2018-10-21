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
    public class CalendarController : ApiController
    {
        #region Fields

        private readonly ICalendarService calendarService;

        #endregion

        #region Constructor

        public CalendarController(ICalendarService calendarService)
        {
            this.calendarService = calendarService;
        }

        #endregion

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var result = new List<AppCalendar>();

                var resultService = await this.calendarService.GetAll();
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
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await this.calendarService.GetById(id);

            if (result != null)
            {
                //var _userVM = Mapper.Map<User, UserViewModel>(_user);
                return this.Json(result);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]AppCalendar vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dateTime = System.DateTime.Now;

            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;

            var resultC = await this.calendarService.Create(vM);
            if (resultC != 1)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            var result = CreatedAtRoute("GetCategory", new { controller = "Category", id = vM.Id }, vM);
            return result;
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody]AppCalendar vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.calendarService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                result.Description = vM.Description;
                result.UpdatedDate = System.DateTime.Now;
                var resultU = await this.calendarService.Update(result);
                if (resultU != 1)
                {
                    return this.StatusCode(HttpStatusCode.BadRequest);
                }
                return this.Ok();
            }
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                var result = await this.calendarService.Delete(id);
                if (result != 1)
                {
                    return this.StatusCode(HttpStatusCode.BadRequest);
                }
                return this.Ok();
            }
        }
    }
}