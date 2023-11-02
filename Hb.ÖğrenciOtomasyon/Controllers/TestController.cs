using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hb.ÖğrenciOtomasyon.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {

            //Console.WriteLine( "sunucuya istek geldi" );


            //return Json(new
            //{
            //    ad="hasan",
            //    soyad="baysal",
            //    yas = 25

            //});


            return PartialView("~/Views/Shared/GetCurrentTime.cshtml");

        }
    }
}
