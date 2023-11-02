using Hb.ÖğrenciOtomasyon.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hb.ÖğrenciOtomasyon.Controllers
{

    public class TestController : Controller
    {

        public static List<Person> people = new List<Person>()
        {

            new(){ID=1, Name="ozan"},
            new(){ID=2, Name="burcu"},
            new(){ID=3, Name="cansın"},
            new(){ID=4, Name="mehmet"},
            new(){ID=5, Name="burak"},
            new(){ID=6, Name="ekrem"},
            new(){ID=10, Name="yaşar"},

        };


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


        public IActionResult GetUserById(int id)
        {

            var user = people.Where(x => x.ID == id).FirstOrDefault();

            return PartialView("~/Views/Shared/UserPartialView.cshtml",user);
        }
    }
}
