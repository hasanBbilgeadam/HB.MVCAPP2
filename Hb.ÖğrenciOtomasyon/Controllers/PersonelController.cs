using Hb.ÖğrenciOtomasyon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hb.ÖğrenciOtomasyon.Controllers
{
    public class PersonelController : Controller
    {

        public static List<Personel> Personels = new List<Personel>()
        {
            new Personel(){ Id=1,Ad="hasan",SoyAd="Baysal"},
            new Personel(){ Id=2,Ad="Ozan",SoyAd="Ulus"},
            new Personel(){ Id=3,Ad="Cansın",SoyAd="Albayrak"},
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetPersonelData(int id)
        {
            var data = Personels.Where(x => x.Id == id).FirstOrDefault();
            return PartialView("~/Views/Shared/PersonelDataPartial.cshtml",data);
        }

        public IActionResult LendProduct()
        {
            var personelListModel = PersonelController.Personels.Select(x => new SelectListItem()
            {
                Text = x.Ad,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.personelListModel = personelListModel;


            var ÜrünListModel = ProductController.Products.Where(x=>!x.PersoneldeMi).Select(x => new SelectListItem()
            {
                Text = x.Adı,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.ÜrünListModel = ÜrünListModel;



            return View();
        }

        [HttpPost]
        public IActionResult LendProduct(int personelId,int productId)
        {

            var p1 = ProductController.Products.Where(x => x.Id == productId).FirstOrDefault();

            ProductController.Products.Remove(p1);

            p1.VerilmeTarihi = DateTime.Now;
            p1.PersoneldeMi = true;

            ProductController.Products.Add(p1);

            //personel'in ürünlerini güncelle
            

            //yarına personelin sahip olduğu ürünleri listeyek sayfası yaz





            return Redirect("/product/list");
        }

    }
}
