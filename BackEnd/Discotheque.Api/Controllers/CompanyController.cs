using DomainModels.Model;
using DomainServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Discotheque.Api.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
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


        [HttpGet()]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = new List<AppCompanie>();

            var resultService = await this.companyService.GetAll();
            var enumerable = resultService.ToList();
            if (enumerable.Any())
            {
                result = enumerable;
            }
            return Json(result);
        }

        //[HttpGet()]
        //public async Task<IHttpActionResult> Get(int id)
        //{
        //    var result = await this.companyService.GetById(id);

        //    if (result != null)
        //    {
        //        //var _userVM = Mapper.Map<User, UserViewModel>(_user);
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost]
        //public async Task<IHttpActionResult> Create([FromBody]AppCompanie vM)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var dateTime = System.DateTime.Now;

        //    vM.CreatedBy = "Obtener Usuario Actual";
        //    vM.CreatedDate = dateTime;
        //    vM.UpdatedDate = dateTime;

        //    //User _newUser = new User { Name = user.Name, Profession = user.Profession, Avatar = user.Avatar };

        //    this.companyService.Add(vM);
        //    //await this.companyService.Commit();

        //    //user = Mapper.Map<User, UserViewModel>(_newUser);

        //    var result = CreatedAtRoute("GetCompany", new { controller = "Company", id = vM.Id }, vM);
        //    return result;
        //}

        //[HttpPut()]
        //public async Task<IHttpActionResult> Put(int id, [FromBody]AppCompanie vM)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await this.companyService.GetById(id);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        this.companyService.Update(result);
        //        //await this.companyService.Commit();
        //    }

        //    //user = Mapper.Map<User, UserViewModel>(_userDb);

        //    return this.StatusCode(HttpStatusCode.BadRequest);
        //}

        //[HttpDelete()]
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //    var result = await this.companyService.GetById(id);

        //    if (result == null)
        //    {

        //        return this.StatusCode(HttpStatusCode.BadRequest);
        //    }
        //    else
        //    {
        //        companyService.Delete(result);

        //        //await companyService.Commit();


        //        return this.StatusCode(HttpStatusCode.BadRequest);
        //    }
        //}
    }
}