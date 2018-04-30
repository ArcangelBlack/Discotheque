using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    public class SchedulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}