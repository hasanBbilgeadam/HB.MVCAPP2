using HB.MVCAPP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HB.MVCAPP2.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.MultiData = new List<SelectListItem>()
            {
                new () { Text ="data1", Value="1" },
                new () { Text ="data2", Value="2"},
                new () { Text ="data3", Value="3"},
                new () { Text ="data4", Value="4"},
            };

            return View();
        }



        [HttpPost]
        public IActionResult TestModelRegister(TestModel vm) 
        {
            
            return View();
        }
    }
}
