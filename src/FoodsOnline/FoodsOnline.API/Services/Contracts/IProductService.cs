using FoodsOnline.API.DTOs.Data;

namespace FoodsOnline.API.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProduct();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDto);
        Task UpdateProduct(ProductDTO productDto);
        Task RemoveProduct(int id);
    }
}
