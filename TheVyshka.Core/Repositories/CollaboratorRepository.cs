﻿using System;
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
    public class CollaboratorRepository: ICollaboratorRepository
    {
        private readonly TheVyshkaContext _context;

        public CollaboratorRepository(TheVyshkaContext context)
        {
            _context = context;
        }
        
        public async Task<CollaboratorList> GetAllAsync(int page, int count)
        {
            var collabCount = _context.Collaborators.Count();
            var take = 0;
            var skip = 0;
            if (count * page < collabCount)
            {
                skip = collabCount - count * page;
                take = count;
            }
            else if (count * page > collabCount && count * (page - 1) < collabCount)
            {
                skip = 0;
                take = collabCount - count * (page - 1);
            }
            else
                return new CollaboratorList
                {
                    Collaborators = new List<CollaboratorDto>(),
                    Count = 0
                };
            var collaborators = CollaboratorConverter.Convert(
                await _context.Collaborators
                    .Skip(skip)
                    .Take(take)
                    // .Include(c => c.PostCollaborator)
                    // .ThenInclude(pc => pc.Post)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync());


            return new CollaboratorList
            {
                Collaborators = collaborators,
                Count = collabCount
            };
        }

        public async Task<CollaboratorDto> GetByIdAsync(int id)
        {
            return CollaboratorConverter.Convert(
                await _context.Collaborators
                    // .Include(c => c.PostCollaborator)
                    // .ThenInclude(pc => pc.Post)
                    .FirstOrDefaultAsync(c => c.Id == id));
        }

        public async Task<CollaboratorDto> CreateAsync(CollaboratorDto item)
        {
            var collaborator = _context.Collaborators.Add(
                CollaboratorConverter.Convert(item));
            await _context.SaveChangesAsync();
            return CollaboratorConverter.Convert(collaborator.Entity);
        }
        
        public async Task<bool> AddToPostAsync(int postId, int collaboratorId, string role)
        {
            await _context.PostCollaborators.AddAsync(new PostCollaborator
            {
                PostId = postId,
                CollaboratorId = collaboratorId,
                Role = role
            });
            await _context.SaveChangesAsync();
            return true;
        } 
        
        public async Task<bool> DeleteFromPostAsync(int postId, int collaboratorId)
        {
            var postCollaborator = await _context.PostCollaborators.
                FirstOrDefaultAsync(p => (p.PostId == postId && p.CollaboratorId == collaboratorId));
            _context.PostCollaborators.Remove(postCollaborator);
            await _context.SaveChangesAsync();
            return true;
        } 

        public async Task<bool> UpdateAsync(CollaboratorDto item)
        {
            if (item == null)
                return false;
            _context.Collaborators.Update(CollaboratorConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var collaborator = await _context
                .Collaborators
                .FindAsync(id);
            if (collaborator == null)
                return false;
            _context.Collaborators.Remove(collaborator);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}