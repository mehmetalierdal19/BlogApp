using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            var values = bm.TGetBlogsWithCategory();
            return View(values);
        }
        public IActionResult BlogDetails(int id)
        {
            var values = bm.TListByID(id); 
            return View(values);
        }
    }
}
