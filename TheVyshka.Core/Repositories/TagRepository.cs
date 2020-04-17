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
        
        public async Task<TagList> GetAllAsync(int page, int count)
        {
            var tagCount = _context.Tags.Count();
            var take = 0;
            var skip = 0;
            if (count * page < tagCount)
            {
                skip = tagCount - count * page;
                take = count;
            }
            else if (count * page > tagCount && count * (page - 1) < tagCount)
            {
                skip = 0;
                take = tagCount - count * (page - 1);
            }
            else
                return new TagList
                {
                    Tags = new List<TagDto>(),
                    Count = 0
                };
            var tags = TagConverter.Convert(
                await _context.Tags
                    .Skip(skip)
                    .Take(take)
                    // .Include(t => t.PostTag)
                    // .ThenInclude(pt => pt.Post)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync());
            
            return new TagList
            {
                Tags = tags,
                Count = tagCount
            };
        }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            return TagConverter.Convert(
                await _context.Tags
                    // .Include(t => t.PostTag)
                    // .ThenInclude(pt => pt.Post)
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