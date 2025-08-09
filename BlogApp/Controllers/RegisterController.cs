using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator writerValidations = new WriterValidator();
            ValidationResult results = writerValidations.Validate(p);

            if (results.IsValid)
            {
                p.Status = true;
                p.About = "Deneme";
                p.Image = "default.png"; // Assuming a default image path
                wm.TAdd(p);

                ViewBag.Message = "Registration successful!";
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();

        }
    }
}
