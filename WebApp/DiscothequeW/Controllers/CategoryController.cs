﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.Models.Models;
using DiscothequeW.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CategoryController : Controller
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = new List<DiscothequeCategory>();

            var resultService = await this.categoryService.GetAll();
            var enumerable = resultService.ToList();
            if (enumerable.Any())
            {
                result = enumerable;
            }
            return Json(result);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.categoryService.GetSingle(id);

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
        public async Task<IActionResult> Create([FromBody]DiscothequeCategory vM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dateTime = System.DateTime.Now;

            vM.CreatedBy = "Obtener Usuario Actual";
            vM.CreatedDate = dateTime;
            vM.UpdatedDate = dateTime;            

            this.categoryService.Add(vM);
            await this.categoryService.Commit();

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            CreatedAtRouteResult result = CreatedAtRoute("GetCategory", new { controller = "Category", id = vM.Id }, vM);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]DiscothequeCategory vM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await this.categoryService.GetSingle(id);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                result.Description = vM.Description;
                result.UpdatedDate = System.DateTime.Now;
                await this.categoryService.Commit();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await this.categoryService.GetSingle(id);

            if (result == null)
            {
                return new NotFoundResult();
            }
            else
            {
                categoryService.Delete(result);

                await categoryService.Commit();

                return new NoContentResult();
            }
        }
    }
}