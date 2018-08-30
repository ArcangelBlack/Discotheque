using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.Models.Models;
using DiscothequeW.Services.Interaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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

        [HttpGet("{id}", Name = "GetCompany")]
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

            var dateTime = System.DateTime.Now;

            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;

            //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

            this.companyService.Add(vM);
            await this.companyService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetCompany", new { controller = "Company", id = vM.Id }, vM);
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
                this.companyService.Update(result);
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
                companyService.Delete(result);

                await companyService.Commit();

                return new NoContentResult();
            }
        }
    }
}