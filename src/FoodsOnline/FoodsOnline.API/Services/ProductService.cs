using AutoMapper;
using FoodsOnline.API.Models;
using FoodsOnline.API.DTOs.Data;
using FoodsOnline.API.Services.Contracts;
using FoodsOnline.API.Repositories.Interfaces;

namespace FoodsOnline.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProduct()
        {
            var entity = await _productRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductDTO>>(entity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var entity = await _productRepository.GetById(id);

            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task AddProduct(ProductDTO productDto)
        {
            var entity = _mapper.Map<Product>(productDto);

            await _productRepository.Create(entity);
            productDto.ProductId = entity.ProductId;
        }

        public async Task UpdateProduct(ProductDTO productDto)
        {
            var entity = _mapper.Map<Product>(productDto);

            await _productRepository.Update(entity);
        }

        public async Task RemoveProduct(int id)
        {
            var entity = _productRepository.GetById(id).Result;

            await _productRepository.Delete(entity.ProductId);
        }
    }
}
