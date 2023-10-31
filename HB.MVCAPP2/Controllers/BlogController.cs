using HB.MVCAPP2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HB.MVCAPP2.Controllers
{
    public class BlogController : Controller
    {

        public static List<Blog> blogList = new()
        {

            new(){
                Id = 1,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300"
            },
             new(){
                Id = 2,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300"
            },

               new(){
                Id = 3,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300"
            },
               new(){
                Id = 4,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300"
            },

        };
        public IActionResult Index()
        {


            return View();
        }
        public IActionResult Post(int id)
        {
            var data = blogList.Where(x => x.Id == id).FirstOrDefault();

            ViewBag.recentBlogs = blogList.Where(x => x.Id != id).ToList();


            return View(data);
        }
    }
}
