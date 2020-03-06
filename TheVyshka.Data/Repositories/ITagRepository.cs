﻿﻿﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheVyshka.Data.Dto;

namespace TheVyshka.Data.Repositories
{
    public interface ITagRepository
    {
        Task<List<TagsDto>> GetAllAsync();
        Task<TagsDto> GetByIdAsync(Guid id);
        Task<TagsDto> CreateAsync(TagsDto item);
        Task<bool> AddToPostAsync(Guid postId, Guid tagId);
        Task<bool> DeleteFromPostAsync(Guid postId, Guid tagId);
        Task<bool> UpdateAsync(TagsDto item);
        Task<bool> DeleteAsync(Guid id);
    }
}