using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheVyshka.Core.EF;
using TheVyshka.Data.Converters;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Entities;
using TheVyshka.Data.Repositories;

namespace TheVyshka.Core.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly TheVyshkaContext _context;

        public CategoryRepository(TheVyshkaContext context)
        {
            _context = context;
        }
        
        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = CategoryConverter.Convert(
                await _context.Categories
                    .ToListAsync());
            
            return categories;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            return CategoryConverter.Convert(
                await _context.Categories
                    // .Include(c => c.PostCategory)
                    // .ThenInclude(pc => pc.Post)
                    .FirstOrDefaultAsync(c => c.Id == id));
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto item)
        {
            var category = _context.Categories.Add(
                CategoryConverter.Convert(item));
            await _context.SaveChangesAsync();
            return CategoryConverter.Convert(category.Entity);
        }

        public async Task<bool> AddToPostAsync(int postId, int categoryId)
        {
            await _context.PostCategories.AddAsync(new PostCategory
            {
                PostId = postId,
                CategoryId = categoryId
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFromPostAsync(int postId, int categoryId)
        {
            var postCategory = await _context.PostCategories.
                FirstOrDefaultAsync(p => (p.PostId == postId && p.CategoryId == categoryId));
            _context.PostCategories.Remove(postCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(CategoryDto item)
        {
            if (item == null)
                return false;
            _context.Categories.Update(CategoryConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context
                .Categories
                .FindAsync(id);
            if (category == null)
                return false;
            _context.Categories.Remove(category);
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}