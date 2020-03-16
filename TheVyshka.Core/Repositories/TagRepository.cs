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
    public class TagRepository: ITagRepository
    {
        private readonly TheVyshkaContext _context;

        public TagRepository(TheVyshkaContext context)
        {
            _context = context;
        }
        
        public async Task<List<TagDto>> GetAllAsync()
        {
            var tags = TagConverter.Convert(
                await _context.Tags
                    .Include(t => t.PostTag)
                    .ThenInclude(pt => pt.Post)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync());
            
            
            return tags;
        }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            return TagConverter.Convert(
                await _context.Tags
                    .Include(t => t.PostTag)
                    .ThenInclude(pt => pt.Post)
                    .FirstOrDefaultAsync(t => t.Id == id));
        }

        public async Task<TagDto> CreateAsync(TagDto item)
        {
            var tag = _context.Tags.Add(
                TagConverter.Convert(item));
            await _context.SaveChangesAsync();
            return TagConverter.Convert(tag.Entity);
        }

        public async Task<bool> AddToPostAsync(int postId, int tagId)
        {
            await _context.PostTags.AddAsync(new PostTag
            {
                PostId = postId,
                TagId = tagId
            });
            await _context.SaveChangesAsync();
            return true;
        } 
        
        public async Task<bool> DeleteFromPostAsync(int postId, int tagId)
        {
            var postTag = await _context.PostTags.
                FirstOrDefaultAsync(p => (p.PostId == postId && p.TagId == tagId));
            _context.PostTags.Remove(postTag);
            await _context.SaveChangesAsync();
            return true;
        } 

        public async Task<bool> UpdateAsync(TagDto item)
        {
            if (item == null)
                return false;
            _context.Tags.Update(TagConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tag = await _context
                .Tags
                .FindAsync(id);
            if (tag == null)
                return false;
            _context.Tags.Remove(tag);
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}