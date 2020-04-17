﻿using System;
using System.Collections.Generic;
 using System.IO;
 using System.Linq;
 using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 using Newtonsoft.Json;
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
        
        public async Task<PostList> GetAllAsync(string selection, int page, int count)
        {
            var postCount = _context.Posts.Count();
            var take = 0;
            var skip = 0;
            if (count * page < postCount)
            {
                skip = postCount - count * page;
                take = count;
            }
            else if (count * page > postCount && count * (page - 1) < postCount)
            {
                skip = 0;
                take = postCount - count * (page - 1);
            }
            else
                return new PostList
                {
                    Posts = new List<PostDto>(),
                    Count = 0
                };
            if (selection == "all")
            {
                var posts = await _context.Posts
                    .Skip(skip)
                    .Take(take)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();

                return new PostList
                {
                    Posts = PostConverter.Convert(posts),
                    Count = postCount
                };
            }
            else
            {
                var posts = await (from p in _context.Posts
                        where p.Status == selection
                        select p)
                    .Skip(skip)
                    .Take(take)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();

                return new PostList
                {
                    Posts = PostConverter.Convert(posts),
                    Count = postCount
                };
            }
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


        public async Task<PostList> GetByCategoryAsync(int categoryId, int page, int count)
        {
            var postIds = await 
                _context.PostCategories
                    .Where(pc => pc.CategoryId == categoryId)
                    .Select(pc => pc.PostId)
                    .ToListAsync();
            var postCount = postIds.Count;
            var take = 0;
            var skip = 0;
            if (count * page < postCount)
            {
                skip = postCount - count * page;
                take = count;
            }
            else if (count * page > postCount && count * (page - 1) < postCount)
            {
                skip = 0;
                take = postCount - count * (page - 1);
            }
            else
                return new PostList
                {
                    Posts = new List<PostDto>(),
                    Count = 0
                };
            var posts = PostConverter.Convert(
                await _context.Posts
                    .Where(p => postIds.Contains(p.Id))
                    .Skip(skip)
                    .Take(take)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .ToListAsync());
        
            return new PostList
            {
                Posts = posts,
                Count = postCount
            };
        }
        
        public async Task<PostList> GetByCollaboratorAsync(int collabId, int page, int count)
        {
            var postIds = await 
                _context.PostCollaborators
                    .Where(pc => pc.CollaboratorId == collabId)
                    .Select(pc => pc.PostId)
                    .ToListAsync();
            var postCount = postIds.Count;
            var take = 0;
            var skip = 0;
            if (count * page < postCount)
            {
                skip = postCount - count * page;
                take = count;
            }
            else if (count * page > postCount && count * (page - 1) < postCount)
            {
                skip = 0;
                take = postCount - count * (page - 1);
            }
            else
                return new PostList
                {
                    Posts = new List<PostDto>(),
                    Count = 0
                };
            var posts = PostConverter.Convert(
                await _context.Posts
                    .Where(p => postIds.Contains(p.Id))
                    .Skip(skip)
                    .Take(take)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .ToListAsync());
        
            return new PostList
            {
                Posts = posts,
                Count = postCount
            };
        }
        public async Task<PostList> GetByNameAsync(string name, int page, int count)
        {
            var postIds = await 
                _context.Posts
                    .Where(p => p.Title.ToLower().Contains(name.ToLower()))
                    .Select(p => p.Id)
                    .ToListAsync();
            var postCount = postIds.Count;
            var take = 0;
            var skip = 0;
            if (count * page < postCount)
            {
                skip = postCount - count * page;
                take = count;
            }
            else if (count * page > postCount && count * (page - 1) < postCount)
            {
                skip = 0;
                take = postCount - count * (page - 1);
            }
            else
                return new PostList
                {
                    Posts = new List<PostDto>(),
                    Count = 0
                };
            var posts = PostConverter.Convert(await 
                _context.Posts
                    .Where(p => postIds.Contains(p.Id))
                    .Skip(skip)
                    .Take(take)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .OrderByDescending(p => p.Id)
                    .ToListAsync());
            
            return new PostList
            {
                Posts = posts,
                Count = posts.Count
            };
        }
        
        public async Task<PostList> GetByTagAsync(int tagId, int page, int count)
        {
            var postIds = await 
                _context.PostTags
                    .Where(pt => pt.TagId == tagId)
                    .Select(pt => pt.PostId)
                    .ToListAsync();
            var postCount = postIds.Count;
            var take = 0;
            var skip = 0;
            if (count * page < postCount)
            {
                skip = postCount - count * page;
                take = count;
            }
            else if (count * page > postCount && count * (page - 1) < postCount)
            {
                skip = 0;
                take = postCount - count * (page - 1);
            }
            else
                return new PostList
                {
                    Posts = new List<PostDto>(),
                    Count = 0
                };
            var posts = PostConverter.Convert(
                await _context.Posts
                    .Where(p => postIds.Contains(p.Id))
                    .Skip(skip)
                    .Take(take)
                    .Include(p => p.PostTag)
                    .ThenInclude(pt => pt.Tag)
                    .Include(p => p.PostCollaborator)
                    .ThenInclude(pc => pc.Collaborator)
                    .Include(p => p.PostCategory)
                    .ThenInclude(pc => pc.Category)
                    .ToListAsync());
        
            return new PostList
            {
                Posts = posts,
                Count = postCount
            };
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