using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tubitak_4007_Project.Models;
using Newtonsoft.Json;

namespace Tubitak_4007_Project.Controllers
{
    public class ShopController : Controller
    {
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

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            var products = ProductService.GetAllProducts();

            products[id-1].amount++;

            return RedirectToAction("ShopPage", "Shop"); 
        }

        [HttpPost]
        public ActionResult DeleteUnitToCart(int id)
        {
            var products = ProductService.GetAllProducts();

            products[id - 1].amount--;

            return RedirectToAction("ShopBasket", "Shop");
        }

        [HttpPost]
        public ActionResult DeleteToCart()
        {
            foreach (var product in ProductService.GetAllProducts())
            {
                product.amount = 0;
            }

            return RedirectToAction("ShopPage", "Shop");
        }

        [HttpPost]
        public ActionResult Payment(MyViewModel myViewModel) {
            return RedirectToAction("AlertPage", "Shop");
        }
    }
}

