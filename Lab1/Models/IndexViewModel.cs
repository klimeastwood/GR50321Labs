using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1.Models
{
    public class IndexViewModel
    {

        // Список для передачи в представление
        public SelectList? MySelectList { get; set; }

        // Для получения выбранного значения
        public int SelectedItemId { get; set; }


    }
}
