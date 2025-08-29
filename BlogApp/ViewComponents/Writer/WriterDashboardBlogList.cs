using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApp.ViewComponents.Writer
{
    public class WriterDashboardBlogList : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.TGetBlogsWithCategory().OrderByDescending(x => x.CreateDate).Take(5).ToList(); 
            return View(values);
        }
    }
}
