using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Dashboard()
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
            var values = bm.TGetBlogsWithCategoryByWriter(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewBlog()
        {
            List<SelectListItem> categoryvalues = (from x in cm.TGetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.cv = categoryvalues;
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
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            blogvalue.Status = false;
            bm.TUpdate(blogvalue);
            return RedirectToAction("MyBlogs");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            List<SelectListItem> categoryvalues = (from x in cm.TGetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            var blogvalue = bm.TGetById(id);
            ViewBag.date = blogvalue.CreateDate;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var existingBlog = bm.TGetById(p.BlogID);
            p.CreateDate = existingBlog.CreateDate;
            p.WriterID = existingBlog.WriterID;
            p.Status = existingBlog.Status;
            bm.TUpdate(p);
            return RedirectToAction("MyBlogs");
        }
    }


}
