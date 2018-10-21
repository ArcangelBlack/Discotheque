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

            var dateTime = System.DateTime.Now;

            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;

            var resultC = await this.userService.Create(vM);
            if (resultC != 1)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }

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
                result.Name = vM.Name;
                result.UpdatedDate = System.DateTime.Now;

                var resultU = await this.userService.Update(result);
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
            var result = await this.userService.GetById(id);

            if (result == null)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                var resultD = await this.userService.Delete(id);
                if (resultD != 1)
                {
                    return this.StatusCode(HttpStatusCode.BadRequest);
                }
                return this.Ok();
            }
        }
    }
}