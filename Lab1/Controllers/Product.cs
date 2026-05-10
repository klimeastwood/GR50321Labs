using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
