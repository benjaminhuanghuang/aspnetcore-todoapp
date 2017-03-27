using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.ViewModels;
using ToDoApp.Services;

namespace ToDoApp.Controllers.App
{
    public class HomeController : Controller
    {
        private IMailer _mailer;

        public HomeController(IMailer mailer)
        {
            _mailer = mailer;

        }

        public IActionResult Index()
        {
            ViewBag.Title = "To Do List";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactVM model)
        {
            ViewBag.Title = "Contact";

            if (ModelState.IsValid)
            {
                _mailer.SendMail(model.FullName, model.Email, model.Message);
                ModelState.Clear();
                ViewBag.Notify = "Message successfully sent.";                                                
            }

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }

    }
}
