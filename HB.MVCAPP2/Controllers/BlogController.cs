using HB.MVCAPP2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;

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
                    new(){ Id = 106,CommentContent="comment xx",BlogId=2,CommentDate = DateTime.Now.AddHours(-5)},
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

                      new(){ Id = 201,CommentContent="comment xx",BlogId=3,CommentDate = DateTime.Now.AddDays(-3)},
                    new(){ Id = 202,CommentContent="comment xx",BlogId=3,CommentDate = DateTime.Now.AddHours(-101)},
                    new(){ Id = 203,CommentContent="comment xx",BlogId=3,CommentDate = DateTime.Now.AddHours(-4)},

                },
            },
               new(){
                Id = 5,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",
                    Comments = new()
                {

                      new(){ Id = 600,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddDays(-6)},
                    new(){ Id = 601,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddMinutes(-10)},
                    new(){ Id = 603,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddHours(-221)},

                },




        },
               new(){
                Id = 8,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",
                    Comments = new()
                {

                      new(){ Id = 800,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddDays(-6)},
                    new(){ Id = 801,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddMinutes(-10)},
                    new(){ Id = 803,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddHours(-221)},

                },




        },      
              new(){
                Id = 411,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",
                    Comments = new()
                {

                      new(){ Id = 1500,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddDays(-6)},
                    new(){ Id = 1501,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddMinutes(-10)},
                    new(){ Id = 1503,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddHours(-221)},

                },




        },
              new(){
                Id = 4123,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",
                    Comments = new()
                {

                      new(){ Id = 67678,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddDays(-6)},
                    new(){ Id = 76,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddMinutes(-10)},
                    new(){ Id = 678,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddHours(-221)},

                },




        },   
            new(){
                Id = 4,
                Content="example blog content , example blog content, example blog content",
                Header="blog header",
                ImagePath="https://picsum.photos/id/1/200/300",
                    Comments = new()
                {

                      new(){ Id = 500,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddDays(-6)},
                    new(){ Id = 501,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddMinutes(-10)},
                    new(){ Id = 503,CommentContent="comment xx",BlogId=4,CommentDate = DateTime.Now.AddHours(-221)},

                },




        },




        };
        public IActionResult Index(int id =1)
        {

            //blog/index/1
            var data= blogList.Skip((id-1)*2).Take(2).ToList();

            ViewBag.CurrentPage = id;
            ViewBag.BlogCount = blogList.Count;




            return View(data);
        }
        public IActionResult Post(int id)
        {
            var data = blogList.Where(x => x.Id == id).FirstOrDefault();

            ViewBag.recentBlogs = blogList.Where(x => x.Id != id).ToList();

            var comments = blogList.Select(x => x.Comments).ToList();

            List<Comment> result = new();
            foreach (var item in comments)
            {
                result.AddRange(item);
            }

            result =  result.OrderByDescending(x => x.CommentDate).ToList();

            ViewBag.recentComments = result.Take(3).ToList();
            return View(data);
            
        }


        [HttpPost]
        public IActionResult CommentAdd(int blogId, string CommentContent)
        {

            var num = new Random().Next(1000, 20000000);
            var blog =   blogList.Where(x => x.Id == blogId).FirstOrDefault();
            blogList.Remove(blog);
            blog.Comments.Add(new Comment() {Id=num, CommentContent = CommentContent, BlogId = blogId, CommentDate = DateTime.Now });
            blogList.Add(blog);




            return RedirectToAction(nameof(Post), new { id=blogId});

        }
    }
}
