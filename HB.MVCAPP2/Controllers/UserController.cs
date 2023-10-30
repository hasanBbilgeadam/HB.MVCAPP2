using HB.MVCAPP2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
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
            TempData["SignUpStatus"]="Başarılı"+" kullanıcı token : "+ user.Token+ " ";
            return Redirect("/home/index");
        }

        public  IActionResult PasswordForget()
        {
            return View();

        }
        [HttpPost]
        public IActionResult PasswordForget(PasswordForgetViewModel vm)
        {

            var user =  list.Where(x => x.Email == vm.Email && vm.Token == x.Token).FirstOrDefault();


            if (user != null)
            {
                TempData["userEmail"] = user.Email;

                return RedirectToAction(nameof(PasswordUpdate));
            }

            TempData["message"] = "bu bilgilerle uyuşan bir kullancı yok"; 
            return Redirect("/home/index");

        }

        public IActionResult PasswordUpdate()
        {

            if (TempData["userEmail"] != null)
            {
                var email =  TempData["userEmail"].ToString();


                return View(new PasswordUpdateViewModel() { Email = email }); ;
            }


            TempData["message"] = "izinsiz bir giriş denemesi";
            return Redirect("/home/index");



        }

        [HttpPost]
        public IActionResult PasswordUpdate(PasswordUpdateViewModel vm)
        {

           var user =  list.Where(x => x.Email == vm.Email).FirstOrDefault();


            AppUser appUser = new();

            appUser = user;
            int token =  appUser.Token = new Random().Next(1000, 10000);

            list.Remove(user);
            list.Add(appUser);

            TempData["newToken"] = token;



            return Redirect("/home/index");
            


        }


    }
}
