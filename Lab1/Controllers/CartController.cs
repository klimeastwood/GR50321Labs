using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Add(int id, string returnUrl)
        {
            
            return Redirect(returnUrl);
        }
    }
}