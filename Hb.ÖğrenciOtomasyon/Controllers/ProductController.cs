using Hb.ÖğrenciOtomasyon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.NetworkInformation;

namespace Hb.ÖğrenciOtomasyon.Controllers
{
    public class ProductController : Controller
    {

        public static List<Product> Products = new(); 
        public IActionResult AddProduct()
        {
            ViewBag.kategoriList = new List<SelectListItem>()
            {
                new("telefon","1"),
                new("tablet","2"),
                new("laptop","3"),
            };
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            Products.Add(p);
            return RedirectToAction("List");
        }

        public IActionResult List()
        {

            return View(Products);
        }
    }
}
