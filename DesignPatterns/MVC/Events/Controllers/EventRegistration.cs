using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Events.ViewModels;

namespace MVC.Events.Controllers
{
    public class EventRegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Register(string id)
        {
            return View(new EventRegistrationViewModel());
        }

        [HttpPost]
        public IActionResult Register(EventRegistrationViewModel model)
        {

        }
    }
}
