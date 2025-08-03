using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class Category : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
