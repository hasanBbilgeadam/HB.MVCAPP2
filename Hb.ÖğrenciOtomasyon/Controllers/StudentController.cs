using Hb.ÖğrenciOtomasyon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hb.ÖğrenciOtomasyon.Controllers
{
    public class StudentController : Controller
    {

        public static List<Student> sList = new();
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult OgrenciKayit()
        {



            ViewBag.Genders = new List<SelectListItem>()
            {

                new(){ Text = "kadın",Value="1"},
                new(){ Text = "Erkek",Value="2"},


            }; 
            ViewBag.ClassLevels = new List<SelectListItem>()
            {

                new(){ Text = "9",Value="9"},
                new(){ Text = "10",Value="10"},
                new(){ Text = "11",Value="11"},
                new(){ Text = "12",Value="12"},


            };

            return View();
        }

        [HttpPost]
        public IActionResult OgrenciKayit(Student vm)
        {


            sList.Add(vm);




            return RedirectToAction(nameof(OgrenciList));

        }

        public IActionResult OgrenciList()
        {
            return View(sList);
        }


        public IActionResult SinavEkle(int id)
        {
            var data =  sList.Where(x => x.Id == id).FirstOrDefault();

            var AllExam = sList.Where(x => x.Id == id).Select(x => x.Examps).FirstOrDefault();

            ViewBag.AllExamp = AllExam;

            ViewBag.SinavTür = new List<SelectListItem>()
            {
                new(){Text="birinci sınav",Value="1"},
                new(){Text="ikinci sınav",Value="2"},
            };
            ViewBag.Ders = new List<SelectListItem>()
            {
                new(){Text="Türke",Value="1"},
                new(){Text="Matematik",Value="2"},
            };

            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult SinavEkle(Examp examp, int id)
        {


            var data = sList.Where(x => x.Id == id).FirstOrDefault();

            sList.Remove(data);


            data.Examps.Add(examp);

            sList.Add(data);


            return RedirectToAction("OgrenciList");

            
        }
    }
}
