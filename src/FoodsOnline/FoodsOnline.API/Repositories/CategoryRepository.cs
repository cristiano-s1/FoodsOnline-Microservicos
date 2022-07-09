using FoodsOnline.API.Models;
using FoodsOnline.API.Context;
using Microsoft.EntityFrameworkCore;
using FoodsOnline.API.Repositories.Interfaces;

namespace FoodsOnline.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categorys.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategorysProducts()
        {
            return await _context.Categorys.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categorys.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categorys.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await GetById(id);
            _context.Categorys.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
