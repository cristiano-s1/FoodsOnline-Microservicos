using FoodsOnline.Web.ViewModels;

namespace FoodsOnline.Web.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
    }
}
