using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApp.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult PartialAddComment(Comment p)
        {
            p.CreateDate = DateTime.Now;
            p.Status = true;
            cm.TAdd(p);
            return Json(new {success = true, message = "Comment successfully submitted!" });
        }
        public PartialViewResult PartialCommentListByBlog(int id)
        {
            var values = cm.TListByBlogID(id);
            return PartialView(values);
        }
    }
}
