using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tubitak_4007_Project.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tubitak_4007_Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var products = ProductService.GetAllProducts();
        string productListJson = JsonConvert.SerializeObject(products);
        Response.Cookies.Append("ProductList", productListJson);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

