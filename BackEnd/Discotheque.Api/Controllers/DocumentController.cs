using DomainModels.Model;
using DomainServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Discotheque.Api.Controllers
{
    public class DocumentController : ApiController
    {
        #region Fields

        private readonly IDocumentService documentService;

        #endregion

        #region Constructor

        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        #endregion

        // GET: /<controller>/
    //    [HttpGet("[action]")]
    //    public IActionResult GetAll()
    //    {
    //        //string realDir = pathProvider.MapPath("~StaticFiles/a.pdf");

    //        //var file = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "SamplePdf.pdf");

    //        //FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);

    //        //byte[] filebytes = new byte[fs.Length];
    //        //fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
    //        //string encodedData = Convert.ToBase64String(filebytes, Base64FormattingOptions.InsertLineBreaks);
    //        //var pdfBytes = encodedData;

    //        string fileName = string.Empty;
    //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "SamplePdf.pdf");

    //        using (MemoryStream ms = new MemoryStream())
    //        {
    //            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    //            {
    //                byte[] bytes = new byte[file.Length];
    //                file.Read(bytes, 0, (int)file.Length);
    //                ms.Write(bytes, 0, (int)file.Length);

    //                var sss = new ByteArrayContent(bytes.ToArray());

    //                var document = new Document
    //                {
    //                    Id = 1,
    //                    Name = "SamplePdf.pdf",
    //                    Data = sss,
    //                    Url = "http://twppdf.azurewebsites.net/api/values/4"
    //                };
    //                return new OkObjectResult(document);

    //                //HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
    //                //httpResponseMessage.Content = sss;
    //                //httpResponseMessage.Content.Headers.Add("x-filename", fileName);
    //                //httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    //                //httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
    //                //httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
    //                //httpResponseMessage.StatusCode = HttpStatusCode.OK;
    //                //return httpResponseMessage;
    //            }
    //        }
    //    }

    //    [HttpGet("[action]")]
    //    //http get as it return file 
    //    public HttpResponseMessage GetPdfFile()
    //    {
    //        //below code locate physcial file on server 
    //        HttpResponseMessage response = null;

    //        var file = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "a.pdf");

    //        //if file present than read file 
    //        var fStream = new FileStream(file, FileMode.Open, FileAccess.Read);
    //        //compose response and include file as content in it
    //        response = new HttpResponseMessage
    //        {
    //            StatusCode = HttpStatusCode.OK,
    //            Content = new StreamContent(fStream)
    //        };
    //        //set content header of reponse as file attached in reponse
    //        response.Content.Headers.ContentDisposition =
    //        new ContentDispositionHeaderValue("attachment")
    //        {
    //            FileName = Path.GetFileName(fStream.Name)
    //        };
    //        //set the content header content type as application/octet-stream as it returning file as reponse 
    //        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

    //        return response;
    //    }


    //    [HttpGet("[action]")]
    //    public HttpResponseMessage GetPdfDownload()
    //    {
    //        try
    //        {
    //            string fileName = string.Empty;
    //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "SamplePdf.pdf");

    //            using (MemoryStream ms = new MemoryStream())
    //            {
    //                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    //                {
    //                    byte[] bytes = new byte[file.Length];
    //                    file.Read(bytes, 0, (int)file.Length);
    //                    ms.Write(bytes, 0, (int)file.Length);

    //                    var sss = new ByteArrayContent(bytes.ToArray());

    //                    HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
    //                    httpResponseMessage.Content = sss;
    //                    httpResponseMessage.Content.Headers.Add("x-filename", fileName);
    //                    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    //                    httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
    //                    httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
    //                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
    //                    return httpResponseMessage;
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return null; //this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
    //        }
    //    }

    //    [HttpGet("[action]")]
    //    //http get as it return file 
    //    public HttpResponseMessage GetTestFile()
    //    {
    //        //below code locate physcial file on server 
    //        HttpResponseMessage response = null;

    //        var file = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles", "a.zip");

    //        //if file present than read file 
    //        var fStream = new FileStream(file, FileMode.Open, FileAccess.Read);
    //        //compose response and include file as content in it
    //        response = new HttpResponseMessage
    //        {
    //            StatusCode = HttpStatusCode.OK,
    //            Content = new StreamContent(fStream)
    //        };
    //        //set content header of reponse as file attached in reponse
    //        response.Content.Headers.ContentDisposition =
    //        new ContentDispositionHeaderValue("attachment")
    //        {
    //            FileName = Path.GetFileName(fStream.Name)
    //        };
    //        //set the content header content type as application/octet-stream as it returning file as reponse 
    //        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

    //        return response;
    //    }
    }
}