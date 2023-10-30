using HB.MVCAPP2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HB.MVCAPP2.Controllers
{
    public class UserController : Controller
    {
        public static List<AppUser> list = new();

        public IActionResult   SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(AppUser user)
        {

            List<String> errors = new List<String>();

            if (user.Password.Contains(user.UserName))
            {
                errors.Add("şifre kullanıcı adı içeremez");
            }
            if (user.Age <=17)
            {
                errors.Add("17'den büyük olmak zorundasınız");
            }
            if (list.Any(x=>x.Email== user.Email)) 
            {
                errors.Add("bu email kayıtlı başka bir email deneyiniz");
            }
            if (user.UserName.Length <=7)
            {
                errors.Add("kullanıcı adı en az 8 karakter olmalı !");
            }

            if (errors.Count > 0)
            {
                //hata var

                //tekrar signup'a gitmem lazım ve hatalar ile birlikte


                TempData["Errors"] = JsonSerializer.Serialize(errors);


                return RedirectToAction(nameof(SignUp));



            }

            list.Add(user);
            TempData["SignUpStatus"]="Başarılı";
            return Redirect("/home/index");
        }



    }
}
