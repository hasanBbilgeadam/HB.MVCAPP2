using HB.MVCAPP2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HB.MVCAPP2.Controllers
{
    public class BlogController : Controller
    {

        public static List<Blog> blogList = new()
        {
               new(){
                Id = 2,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",


                     Comments = new()
                {

                      new(){ Id = 105,CommentContent="comment xx",BlogId=2,CommentDate = DateTime.Now.AddDays(-1)},
                    new(){ Id = 106,CommentContent="comment xx",BlogId=2,CommentDate = DateTime.Now.AddHours(-1)},
                    new(){ Id = 107,CommentContent="comment xx",BlogId=2,CommentDate = DateTime.Now.AddHours(-222)},

                },
            },
               new(){
                Id = 3,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",
                    Comments = new()
                {

                      new(){ Id = 201,CommentContent="comment xx",BlogId=3,CommentDate = DateTime.Now.AddDays(-1)},
                    new(){ Id = 202,CommentContent="comment xx",BlogId=3,CommentDate = DateTime.Now.AddHours(-101)},
                    new(){ Id = 203,CommentContent="comment xx",BlogId=3,CommentDate = DateTime.Now.AddHours(-1)},

                },
            },
               new(){
                Id = 4,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",
                    Comments = new()
                {

                      new(){ Id = 500,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddDays(-1)},
                    new(){ Id = 501,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddMinutes(-10)},
                    new(){ Id = 503,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddHours(-222)},

                },
            }

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
