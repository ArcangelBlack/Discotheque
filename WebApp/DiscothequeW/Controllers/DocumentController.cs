using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiscothequeW.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        // GET: /<controller>/
        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            FileStream fs = new FileStream(@"/Resources/a.pdf", FileMode.Open, FileAccess.Read);

            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            string encodedData = Convert.ToBase64String(filebytes, Base64FormattingOptions.InsertLineBreaks);
            var pdfBytes = encodedData;

            //var fileContent = System.IO.File.
            //byte[] pdfBytes = System.IO.File.ReadAllBytes(reportname);

           
            var document = new Document();
            document.Id = 1;
            document.Name = "a.pdf";
            document.Data = pdfBytes;
            document.Url = "http://twppdf.azurewebsites.net/api/values/4";
            return View();
        }
    }
}
