using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;



namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        // GET: /<controller>/
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(CreateUserRegisterRequest register)
        {
           var response =  _userService.Register(register);
            return View(response);
        }
    }
}
