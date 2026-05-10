using Lab1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab1.Controllers
{
    public class ProductController(IProductService pService, ICategoryService sService) : Controller
    {

        public async Task<IActionResult> Index(string? category)
        {
            // получить список категорий
            var categoriesResponse = await sService.GetCategoryListAsync();

            // если список не получен, вернуть код 404
            if (!categoriesResponse.Success)
                return NotFound(categoriesResponse.ErrorMessage);

            // передать список категорий во ViewData        
            ViewData["categories"] = categoriesResponse.Data;

            // передать во ViewData имя текущей категории 
            var currentCategory = category == null
                ? "Все"
                : categoriesResponse.Data.FirstOrDefault(c => c.NormalizedName == category)?.Name;
            ViewData["currentCategory"] = currentCategory;


            var dishes = await pService.GetProductListAsync(category);

            if (!dishes.Success)
                ViewData["Error"] = dishes.ErrorMessage;

            return View(dishes.Data.Items);
        }

    }
}
