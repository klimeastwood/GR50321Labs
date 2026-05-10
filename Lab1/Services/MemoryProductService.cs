using Microsoft.AspNetCore.Mvc;

namespace Lab1.Services
{
    public class MemoryProductService : IProductService
    {
        private readonly ICategoryService _categoryService;
        //private readonly IConfigurations _config;

        List<Dish> _dishes;
        List<Category> _categories;

        public MemoryProductService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _categories = _categoryService.GetCategoryListAsync().Result.Data;
            //_config = config;
            SetupData();
        }
        /// <summary> 
        /// Инициализация списков 
        /// </summary> 
        private void SetupData()
        {
            _dishes = new List<Dish>
            {
                new Dish {Id = 1, Name="Пирожки",
                    Description="Сладкие как мед",
                    Calories =200, Image="Images/starter.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("starters")).Id},
                new Dish {Id = 2, Name="Суп-харчо",
                    Description="Очень острый, невкусный",
                    Calories =200, Image="Images/soup.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("soups")).Id},
                new Dish { Id = 3, Name="Мимоза",
                    Description="Вкусный салат",
                    Calories =330, Image="Images/salad.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("salads")).Id},
                 new Dish { Id = 4, Name="Котлеты по-Аризонски",
                    Description="Мясо бизона",
                    Calories =330, Image="Images/dish.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("main-dishes")).Id},
                 new Dish { Id = 5, Name="Мороженое",
                    Description="Обычный пломбир",
                    Calories =330, Image="Images/dessert.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("desserts")).Id},
                 new Dish { Id = 6, Name="Коктейль Фламинго",
                    Description="Дает в голову",
                    Calories =330, Image="Images/drink.jpg",
                    CategoryId=_categories.Find(c=>c.NormalizedName.Equals("drinks")).Id},
            };
        }
        public Task<ResponseData<ListModel<Dish>>> GetProductListAsync(string?
        categoryNormalizedName, int pageNo = 1)
        {
            // Создать объект результата
            ResponseData<ListModel<Dish>> result = new();

            // Id категории для фильтрации
            int? categoryId = null;

            // если требуется фильтрация, то найти Id категории
            // с заданным categoryNormalizedName
            if (categoryNormalizedName != null)
                categoryId = _categories
                .Find(c => c.NormalizedName.Equals(categoryNormalizedName))
                ?.Id;

            // Выбрать объекты, отфильтрованные по Id категории,
            // если этот Id имеется
            var data = _dishes
                .Where(d => categoryId == null || d.CategoryId.Equals(categoryId))
                ?.ToList();

            //int pageSize = _config.GetSection("ItemPerPage").Get<int>();

            // int totalPages = (int)Math.Ceiling(data.Count / (double)pageSize);

            var listData = new ListModel<Dish>()
            {
                Items = data,

                // Items = data.Skip((pageNo) - 1) * pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                TotalPages = 100 //totalPages
            };

            result.Data = listData;

            if (data == null || data.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбранной категории";
            }
            return Task.FromResult(result);
        }

        //для последующей реализации методы
        public Task UpdateProductAsync(int id, Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Dish>> CreateProductAsync(Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Dish>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}