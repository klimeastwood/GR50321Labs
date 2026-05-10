namespace Lab1.Services

{
    public interface ICategoryService
    {
        /// <summary> 
        /// Получение списка всех категорий 
        /// </summary> 
        /// <returns></returns> 
        public Task<ResponseData<List<Category>>> GetCategoryListAsync();
    }
}
