using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Esercizio_login_user.Models;
using Esercizio_login_user.Models.Services.Application;
using Esercizio_login_user.Models.ViewModels;

namespace Esercizio_login_user.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginUtente(string username, string password)
        {
            return loginService.CheckUtente(username, password) ? RedirectToAction("Index", "Home") : RedirectToAction("Index");
        }
    }
}