﻿﻿﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheVyshka.Data.Dto;

namespace TheVyshka.Data.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<List<CollaboratorDto>> GetAllAsync();
        Task<CollaboratorDto> GetByIdAsync(int id);
        Task<CollaboratorDto> CreateAsync(CollaboratorDto item);
        Task<bool> AddToPostAsync(int postId, int collaboratorId);
        Task<bool> DeleteFromPostAsync(int postId, int collaboratorId);
        Task<bool> UpdateAsync(CollaboratorDto item);
        Task<bool> DeleteAsync(int id);
    }
}