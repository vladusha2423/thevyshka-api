using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Repositories
{
    public interface IPostRepository
    {
        Task<PostList> GetAllAsync(string selection, int page, int count);
        Task<PostDto> GetByIdAsync(int id);
        // Task<List<PostCollaborator>> GetLinks();
        Task<bool> Initial();
        Task<PostList> GetByCollaboratorAsync(int collabId, int page, int count);
        Task<PostList> GetByCategoryAsync(int collabId, int page, int count);
        Task<PostList> GetByTagAsync(int tagId, int page, int count);
        Task<PostList> GetByNameAsync(string name, int page, int count);
        Task<PostDto> CreateAsync(PostDto item);
        Task<bool> UpdateAsync(PostDto item);
        Task<bool> DeleteAsync(int id);
    }
}