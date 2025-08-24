using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterHeaderNavbarPartial()
        {
            return PartialView();
        }
        public IActionResult MyBlogs()
        {
            var values = bm.TGetBlogListByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewBlog(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            else
            {
                blog.CreateDate = DateTime.Now;
                blog.Status = true;
                blog.WriterID = 1;
                bm.TAdd(blog);
                return RedirectToAction("MyBlogs");
            }
            
        }
    }


}
