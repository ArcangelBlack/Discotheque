using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using D.Models.GoogleModels;
using D.Models.Models;
using DiscothequeW.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DiscothequeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

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
    }
}