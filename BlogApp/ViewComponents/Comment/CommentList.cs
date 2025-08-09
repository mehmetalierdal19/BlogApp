using BlogApp.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogApp.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.TListByBlogID(id);
            return View(values);
        }
    }
}
