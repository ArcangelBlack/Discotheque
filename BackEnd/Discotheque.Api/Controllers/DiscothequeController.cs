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
    public class DiscothequeController : ApiController
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

        [HttpGet()]
        public async Task<IHttpActionResult> GetAvailables()
        {
            //API Key
            const string apiKey = "AIzaSyCzUGfbgbzOPERSArlTI8kAjphhsIFVGXU";

            //The custom search engine identifier
            const string searchEngineId = "012492674958042532303:q2ey6tmaaru";

            const string query = "Discotecas de Trujillo";

            //var tmpList = new List<ItemModel>();

            //var result = new GoogleSearch
            //{
            //    Key = apiKey,
            //    CX = searchEngineId
            //};
            //result.SearchCompleted += (a, b) =>
            //{
            //    tmpList = b.Response.Items;
            //};
            //result.Search(query);

            return this.StatusCode(HttpStatusCode.BadRequest);
        }

        [HttpGet()]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = new List<AppDiscotheque>();

            var resultService = await this.discothequeService.GetAll();
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
            var result = await this.discothequeService.GetById(id);

            if (result != null)
            {
                //var _userVM = Mapper.Map<User, UserViewModel>(_user);
                return  Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]AppDiscotheque vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dateTime = System.DateTime.Now;
            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;

            this.discothequeService.Add(vM);
            //await this.discothequeService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            var result = CreatedAtRoute("GetEmployee", new { controller = "Employee", id = vM.Id }, vM);
            return result;
        }

        [HttpPut()]
        public async Task<IHttpActionResult> Put(int id, [FromBody]AppDiscotheque vM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await this.discothequeService.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    result.WebSite = vM.WebSite;
                    result.UpdatedDate = System.DateTime.Now;

                    this.discothequeService.Update(result);
                    //await this.discothequeService.Commit();
                }
                return this.StatusCode(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return this.StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete()]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await this.discothequeService.GetById(id);

            if (result == null)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }
            else
            {
                this.discothequeService.Delete(result);

                //await this.discothequeService.Commit();

                return this.StatusCode(HttpStatusCode.BadRequest);
            }
        }
    }
}