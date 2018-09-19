using DomainModels.Model;
using DomainServices.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Discotheque.Api.Controllers
{
    public class CalendarController : ApiController
    {
        #region Fields

        #endregion

        #region Constructor

        #endregion

        public IHttpActionResult Index()
        {
            return this.Ok();
        }
    }
}