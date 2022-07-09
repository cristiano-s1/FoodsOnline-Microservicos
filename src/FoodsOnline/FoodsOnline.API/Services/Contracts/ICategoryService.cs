using FoodsOnline.API.DTOs.Data;

namespace FoodsOnline.API.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategory();
        Task<IEnumerable<CategoryDTO>> GetCategorysProducts();
        Task<CategoryDTO> GetCategoryById(int id);
        Task AddCategory(CategoryDTO categoryDto);
        Task UpdateCategory(CategoryDTO categoryDto);
        Task RemoveCategory(int id);
    }
}
