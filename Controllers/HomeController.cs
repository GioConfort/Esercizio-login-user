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
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public IActionResult Index()
        {
            List<UtentiViewModel> utenti = homeService.GetUtenti();
            return View(utenti);
        }
        public IActionResult Aggiungi()
        {
            return View();
        }
        public IActionResult AggiungiUtente(string username, string nome, string email, string password)
        {
            homeService.AddUtente(username, nome, email, password);
            List<UtentiViewModel> utenti = homeService.GetUtenti();
            return RedirectToAction("Index");
        }
        public IActionResult RimuoviUtente(int id)
        {
            homeService.RemoveUtente(id);
            List<UtentiViewModel> utenti = homeService.GetUtenti();
            return RedirectToAction("Index");
        }
    }
}
