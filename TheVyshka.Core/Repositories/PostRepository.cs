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
    public class PostRepository: IPostRepository
    {
        private readonly TheVyshkaContext _context;

        public PostRepository(TheVyshkaContext context)
        {
            _context = context;
        }
        
        public async Task<List<PostDto>> GetAllAsync(int page, int count)
        {
            // var posts = PostConverter.Convert(
            //     await _context.Posts
            //         .Skip(count * (page - 1))
            //         .Take(count)
            //         .Include(p => p.PostTag)
            //         .ThenInclude(pt => pt.Tag)
            //         .Include(p => p.PostCollaborator)
            //         .ThenInclude(pc => pc.Collaborator)
            //         .ToListAsync());
            var posts = await _context.Posts
                    .Skip(_context.Posts.Count() - count * page)
                    .Take(count)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();
            return PostConverter.Convert(posts);
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            var post = PostConverter.Convert(
                await _context.Posts
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .FirstOrDefaultAsync(p => p.Id == id)
                );
            
            
            return post;
        }
        
        // public async Task<List<PostDto>> GetByRubricAsync(string rubric, int page, int count)
        // {
        //     var posts = PostConverter.Convert(await 
        //         _context.Posts
        //             .Skip(count * (page - 1))
        //             .Take(count)
        //             .Include(p => p.PostTag)
        //             .ThenInclude(pt => pt.Tag)
        //             .Include(p => p.PostCollaborator)
        //             .ThenInclude(pc => pc.Collaborator)
        // .Include(p => p.PostCategory)
        //     .ThenInclude(pc => pc.Category)
        //             .Where(p => p.Rubric == rubric)
        //             .ToListAsync());
        //
        //     return posts;
        // }
        
        public async Task<List<PostDto>> GetByCollaboratorAsync(int collabId, int page, int count)
        {
            var posts = PostConverter.Convert(
                await (from pq in _context.Posts
                    join pc in _context.PostCollaborators on pq.Id equals pc.PostId
                    join c in _context.Collaborators on pc.CollaboratorId equals c.Id
                    where c.Id == collabId
                    select pq)
                    .Skip(count * (page - 1))
                    .Take(count)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync());
            
            
            return posts;
        }
        
        public async Task<List<PostDto>> GetByNameAsync(string name, int page, int count)
        {
            var posts = PostConverter.Convert(await 
                (from pq in _context.Posts
                    where pq.Title == name
                    select pq)
                .Skip(count * (page - 1))
                .Take(count)
                .Include(p => p.PostTag)
                .ThenInclude(pt => pt.Tag)
                .Include(p => p.PostCollaborator)
                .ThenInclude(pc => pc.Collaborator)
                .Include(p => p.PostCategory)
                .ThenInclude(pc => pc.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync());
            
            
            return posts;
        }
        
        public async Task<List<PostDto>> GetByTagAsync(int tagId, int page, int count)
        {
            var posts = PostConverter.Convert(
                await (from pq in _context.Posts
                    join pt in _context.PostTags on pq.Id equals pt.PostId
                    join t in _context.Tags on pt.TagId equals t.Id
                    where t.Id == tagId 
                    select pq)
                    .Skip(count * (page - 1))
                    .Take(count)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync());
            
           
            return posts;
        }

        public async Task<PostDto> CreateAsync(PostDto item)
        {
            var post = _context.Posts.Add(
                PostConverter.Convert(item));
            
            // if (item.Collaborators != null)
            // {
            //     foreach (var collaborator in item.Collaborators)
            //     {
            //         _context.PostCollaborators.Add(new PostCollaborator
            //         {
            //             PostId = item.Id,
            //             CollaboratorId = collaborator.Id
            //         });
            //     }
            // }
            //
            // if (item.Tags != null)
            // {
            //     foreach (var tag in item.Tags)
            //     {
            //         _context.PostTags.Add(new PostTag
            //         {
            //             PostId = item.Id,
            //             TagId = tag.Id
            //         });
            //     }
            // }

            await _context.SaveChangesAsync();
            return PostConverter.Convert(post.Entity);
        }

        public async Task<bool> UpdateAsync(PostDto item)
        {
            if (item == null)
                return false;
            _context.Posts.Update(PostConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
                return false;
            _context.Posts.Remove(post);
            // foreach (var postTag in _context.PostTags)
            // {
            //     if (postTag.PostId == post.Id)
            //     {
            //         _context.Remove(postTag);
            //     }
            // }
            // foreach (var postCollaborator in _context.PostCollaborators)
            // {
            //     if (postCollaborator.PostId == post.Id)
            //     {
            //         _context.Remove(postCollaborator);
            //     }
            // }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}