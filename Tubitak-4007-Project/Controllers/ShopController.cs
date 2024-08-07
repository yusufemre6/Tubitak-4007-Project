using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tubitak_4007_Project.Controllers
{
    public class ShopController : Controller
    {
        // GET: /<controller>/
        public IActionResult ShopPage()
        {
            ViewBag.IsShop = "True";
            return View();
        }

        public IActionResult ShopBasket()
        {
            ViewBag.IsShop = "True";
            return View();
        }
    }
}

