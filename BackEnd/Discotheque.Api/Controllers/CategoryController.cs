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
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        #region Fields

        private readonly ICategoryService categoryService;

        #endregion

        #region Constructor

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #endregion

        [HttpGet()]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var result = new List<AppDiscothequeCategorie>();

                var resultService = await this.categoryService.GetAll();
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
        public async Task<IHttpActionResult> Get(int id)
        {
            //var result = await this.categoryService.GetById(id);

            //if (result != null)
            //{
            //    //var _userVM = Mapper.Map<User, UserViewModel>(_user);
            //    return this.Ok(result);
            //}

            return this.StatusCode(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]AppDiscothequeCategorie vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dateTime = System.DateTime.Now;

            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;

            //this.categoryService.Add(vM);
            //await this.categoryService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            var result = CreatedAtRoute("GetCategory", new { controller = "Category", id = vM.Id }, vM);
            return result;
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody]AppDiscothequeCategorie vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var result = await this.categoryService.GetById(id);

            //if (result == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    result.Description = vM.Description;
            //    result.UpdatedDate = System.DateTime.Now;
            //    //await this.categoryService.Commit();
            //}
            return this.Ok();
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            //var result = await this.categoryService.GetById(id);

            //if (result == null)
            //{

            //    return this.StatusCode(HttpStatusCode.BadRequest);
            //}
            //else
            //{
            //    //categoryService.Delete(result);

            //    //await categoryService.Commit();


            return this.StatusCode(HttpStatusCode.BadRequest);
            //}
        }

    }
}