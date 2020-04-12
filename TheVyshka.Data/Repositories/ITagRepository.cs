﻿﻿﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheVyshka.Data.Dto;

namespace TheVyshka.Data.Repositories
{
    public interface ITagRepository
    {
        Task<TagList> GetAllAsync(int page, int count);
        Task<TagDto> GetByIdAsync(int id);
        Task<TagDto> CreateAsync(TagDto item);
        Task<bool> AddToPostAsync(int postId, int tagId);
        Task<bool> DeleteFromPostAsync(int postId, int tagId);
        Task<bool> UpdateAsync(TagDto item);
        Task<bool> DeleteAsync(int id);
    }
}