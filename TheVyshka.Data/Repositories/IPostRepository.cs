using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheVyshka.Data.Dto;

namespace TheVyshka.Data.Repositories
{
    public interface IPostRepository
    {
        Task<List<PostDto>> GetAllAsync(int page, int count);
        Task<PostDto> GetByIdAsync(Guid id);
        Task<List<PostDto>> GetByRubricAsync(string rubric, int page, int count);
        Task<List<PostDto>> GetByCollaboratorAsync(string collaboratorName, int page, int count);
        Task<List<PostDto>> GetByTagAsync(string tagName, int page, int count);
        Task<List<PostDto>> GetByNameAsync(string name, int page, int count);
        Task<PostDto> CreateAsync(PostDto item);
        Task<bool> UpdateAsync(PostDto item);
        Task<bool> DeleteAsync(Guid id);
    }
}