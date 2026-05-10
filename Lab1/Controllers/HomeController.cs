using Lab1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Lab1.Controllers
{
    public class HomeController : Controller
    {

        //[Authorize(Policy ="admin")]

        public IActionResult Index()
        {
            // Пункт c: Передача текста через ViewData
            ViewData["LabTitle"] = "Лабораторная работа №2";

            // Создание данных для выпадающего списка
            var items = new List<ListDemo>
            {
                new ListDemo { Id = 1, Name = "Item1" },
                new ListDemo { Id = 2, Name = "Item2" },
                new ListDemo { Id = 3, Name = "Item3" },
            };

            // Создаём модель для представления
            var viewModel = new IndexViewModel
            {
                // SelectList: источник, поле для Value, поле для Text
                MySelectList = new SelectList(items, "Id", "Name"),
                SelectedItemId = 1 // Значение по умолчанию
            };

            // Пункт d: Передаём модель в представление
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            // Сохраняем заголовок
            ViewData["LabTitle"] = "Лабораторная работа №2";

            // Заново создаём список для отображения (данные не теряются)
            var items = new List<ListDemo>
            {
                new ListDemo { Id = 1, Name = "Item1" },
                new ListDemo { Id = 2, Name = "Item2" },
                new ListDemo { Id = 3, Name = "Item3" },
            };

            model.MySelectList = new SelectList(items, "Id", "Name", model.SelectedItemId);

            // Сохраняем сообщение о выбранном значении для отображения
            ViewData["SelectedMessage"] = $"Выбран ID: {model.SelectedItemId}";

            return View(model);
        }
    }
}
