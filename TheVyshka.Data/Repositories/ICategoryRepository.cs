using System.Collections.Generic;
using System.Threading.Tasks;
using TheVyshka.Data.Dto;

namespace TheVyshka.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CategoryDto item);
        Task<bool> AddToPostAsync(int postId, int categoryId);
        Task<bool> DeleteFromPostAsync(int postId, int categoryId);
        Task<bool> UpdateAsync(CategoryDto item);
        Task<bool> DeleteAsync(int id);
    }
}