using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.SendDate = DateTime.Now;
            p.Status = true;
            cm.TAdd(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
