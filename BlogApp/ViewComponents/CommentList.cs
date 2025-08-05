using BlogApp.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogApp.ViewComponents
{
    public class CommentList : ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.TListByBlogID(7);
            return View(values);
        }
    }
}
