using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using D.Models.Models;
using DiscothequeW.Services.Interfaces;
using DiscothequeW.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiscothequeW.Controllers
{
    public class UserController : Controller
    {
        #region Fields

        //private readonly IUserService userService;

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("{id}", Name = "GetUser")]
        //public IActionResult Get(int id)
        //{
        //    var _user = userService.GetSingle(u => u.Id == id);

        //    if (_user != null)
        //    {
        //        var userVm = Mapper.Map<User, UserVm>(_user);
        //        return new OkObjectResult(userVm);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost]
        //public IActionResult Create([FromBody]UserVm user)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    User _newUser = new User { Name = user., Profession = user.Profession, Avatar = user.Avatar };

        //    userService.Add(_newUser);
        //    userService.Commit();

        //    user = Mapper.Map<User, UserVm>(_newUser);

        //    CreatedAtRouteResult result = CreatedAtRoute("GetUser", new { controller = "Users", id = user.Id }, user);
        //    return result;
        //}
    }
}