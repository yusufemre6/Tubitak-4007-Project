using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tubitak_4007_Project.Models;

namespace Tubitak_4007_Project.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(User user)
        {
            TempData["UserEmail"] = user.userEmail;
            TempData["UserPass"] = user.userPassword;
            return RedirectToAction("AlertPage", "Authentication"); 
        }

        public IActionResult AlertPage() {
            ViewBag.UserEmail = TempData["UserEmail"];
            ViewBag.UserPass = TempData["UserPass"];
            return View();
        }
    }
}

