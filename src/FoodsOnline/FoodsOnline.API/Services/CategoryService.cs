using AutoMapper;
using FoodsOnline.API.Models;
using FoodsOnline.API.DTOs.Data;
using FoodsOnline.API.Services.Contracts;
using FoodsOnline.API.Repositories.Interfaces;

namespace FoodsOnline.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategory()
        {
            var entity = await _categoryRepository.GetAll();

            return _mapper.Map<IEnumerable<CategoryDTO>>(entity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategorysProducts()
        {
            var entity = await _categoryRepository.GetCategorysProducts();

            return _mapper.Map<IEnumerable<CategoryDTO>>(entity);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var entity = await _categoryRepository.GetById(id);

            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task AddCategory(CategoryDTO categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.Create(entity);
            categoryDto.CategoryId = entity.CategoryId;
        }

        public async Task UpdateCategory(CategoryDTO categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.Update(entity);
        }

        public async Task RemoveCategory(int id)
        {
            var entity = _categoryRepository.GetById(id).Result;

            await _categoryRepository.Delete(entity.CategoryId);
        }
    }
}
