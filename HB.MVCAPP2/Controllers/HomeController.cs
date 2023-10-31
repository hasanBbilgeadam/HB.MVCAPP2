using HB.MVCAPP2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HB.MVCAPP2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {


            var list = new List<AppUser>()
            {

                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
                new(){Name="a", Email="hasdasd@gmail.com",UserName="asd"},
            
            };

            ViewBag.users = list;
            return View(list);
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
}