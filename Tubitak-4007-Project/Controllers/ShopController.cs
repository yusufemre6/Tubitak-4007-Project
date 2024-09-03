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
            
            string productListJson = Request.Cookies["ProductList"];

            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(productListJson);
            MyViewModel myViewModel = new MyViewModel();
            myViewModel.Products = productList;
            return View(myViewModel);
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            //var products = ProductService.GetAllProducts();

            //products[id-1].amount++;

            // Cookie'den JSON formatındaki listeyi al
            string productListJson = Request.Cookies["ProductList"];

            // JSON'u listeye çevir
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(productListJson);

            // Ürünü bul ve amount değerini güncelle
            Product product = productList.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.amount +=1;

                // Güncellenen listeyi tekrar JSON formatına çevir
                productListJson = JsonConvert.SerializeObject(productList);

                // Güncellenmiş listeyi tekrar cookie'ye kaydet
                Response.Cookies.Append("ProductList", productListJson);
            }

            return RedirectToAction("ShopPage", "Shop"); 
        }

        [HttpPost]
        public ActionResult DeleteUnitToCart(int id)
        {
            //var products = ProductService.GetAllProducts();

            //products[id - 1].amount--;

            // Cookie'den JSON formatındaki listeyi al
            string productListJson = Request.Cookies["ProductList"];

            // JSON'u listeye çevir
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(productListJson);

            // Ürünü bul ve amount değerini güncelle
            Product product = productList.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.amount -= 1;

                // Güncellenen listeyi tekrar JSON formatına çevir
                productListJson = JsonConvert.SerializeObject(productList);

                // Güncellenmiş listeyi tekrar cookie'ye kaydet
                Response.Cookies.Append("ProductList", productListJson);
            }

            return RedirectToAction("ShopBasket", "Shop");
        }

        [HttpPost]
        public ActionResult DeleteToCart()
        {
            // Cookie'den JSON formatındaki listeyi al
            string productListJson = Request.Cookies["ProductList"];

            // JSON'u listeye çevir
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(productListJson);

            foreach (var product in productList)
            {
                product.amount = 0;
            }

            // Güncellenen listeyi tekrar JSON formatına çevir
            productListJson = JsonConvert.SerializeObject(productList);

            // Güncellenmiş listeyi tekrar cookie'ye kaydet
            Response.Cookies.Append("ProductList", productListJson);
            
            return RedirectToAction("ShopPage", "Shop");
        }

        [HttpPost]
        public ActionResult Payment(MyViewModel myViewModel) {
            if (myViewModel.CreditCard.CardNumber==null || myViewModel.CreditCard.Cvv == null || myViewModel.CreditCard.ExpiryDate == null){
                return RedirectToAction("ShopBasket", "Shop");
            }
            else{
                return View(myViewModel);
            }
        }
    }
}

