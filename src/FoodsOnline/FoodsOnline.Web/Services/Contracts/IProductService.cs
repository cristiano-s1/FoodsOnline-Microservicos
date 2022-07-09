using FoodsOnline.Web.ViewModels;

namespace FoodsOnline.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        Task<ProductViewModel> Create(ProductViewModel productViewModel);
        Task<ProductViewModel> Update(ProductViewModel productViewModel);
        Task<bool> Delete(int id);
    }
}
