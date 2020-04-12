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
            if (selection == "all")
            {
                var posts = await _context.Posts
                    .Skip(postCount - count * page)
                    .Take(count)
                    // .Include(p => p.PostTag)
                    // .ThenInclude(pt => pt.Tag)
                    // .Include(p => p.PostCollaborator)
                    // .ThenInclude(pc => pc.Collaborator)
                    // .Include(p => p.PostCategory)
                    // .ThenInclude(pc => pc.Category)
                    // .OrderByDescending(p => p.Id)
                    .OrderBy(p => p.Id)
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
                    .Skip(postCount - count * page)
                    .Take(count)
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

        // public async Task<List<PostCollaborator>> GetLinks(){
        //     return await _context.PostCollaborators.ToListAsync();
        // }

        public async Task<bool> Initial()
        {
            // string path = @"D:\Projects\TheVyshka\posts.json";
            // using (StreamReader sr = new StreamReader(path))
            // {
            //     var str = sr.ReadToEnd();
            //     var list = JsonConvert.DeserializeObject<List<Post>>(str);
            //     foreach(var p in list)
            //     {
            //         p.Id = 0;
            //     }
            //     await _context.Posts.AddRangeAsync(list);
            //     await _context.SaveChangesAsync();
            // }
            string path = @"D:\Projects\TheVyshka\tags.json";
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<Tag>>(str);
                foreach(var p in list)
                {
                    p.Id = 0;
                }
                await _context.Tags.AddRangeAsync(list);
                await _context.SaveChangesAsync();
            }
            path = @"D:\Projects\TheVyshka\categories.json";
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<Category>>(str);
                foreach(var p in list)
                {
                    p.Id = 0;
                }
                await _context.Categories.AddRangeAsync(list);
                await _context.SaveChangesAsync();
            }
            path = @"D:\Projects\TheVyshka\collaborators.json";
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<Collaborator>>(str);
                foreach(var p in list)
                {
                    p.Id = 0;
                }
                await _context.Collaborators.AddRangeAsync(list);
                await _context.SaveChangesAsync();
            }
            path = @"D:\Projects\TheVyshka\postCollaborators.json";
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<PostCollaborator>>(str);
                await _context.PostCollaborators.AddRangeAsync(list);
                await _context.SaveChangesAsync();
            }
            path = @"D:\Projects\TheVyshka\postTags.json";
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<PostTag>>(str);
                await _context.PostTags.AddRangeAsync(list);
                await _context.SaveChangesAsync();
            }
            path = @"D:\Projects\TheVyshka\postCategories.json";
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadToEnd();
                var list = JsonConvert.DeserializeObject<List<PostCategory>>(str);
                await _context.PostCategories.AddRangeAsync(list);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        
        public async Task<PostList> GetByCategoryAsync(int categoryId, int page, int count)
        {
            var postCount = _context.Posts.Count();
            var posts = PostConverter.Convert(await 
                (from pq in _context.Posts
                    join pc in _context.PostCategories on pq.Id equals pc.PostId
                    join c in _context.Categories on pc.CategoryId equals c.Id
                    where c.Id == categoryId
                    select pq)
                    .Skip(postCount - count * page)
                    .Take(count)
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
            var postCount = _context.Posts.Count();
            var posts = PostConverter.Convert(
                await (from pq in _context.Posts
                    join pc in _context.PostCollaborators on pq.Id equals pc.PostId
                    join c in _context.Collaborators on pc.CollaboratorId equals c.Id
                    where c.Id == collabId
                    select pq)
                    .Skip(postCount - count * page)
                    .Take(count)
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
                Count = postCount
            };
        }
        public async Task<PostList> GetByNameAsync(string name, int page, int count)
        {
            var postCount = _context.Posts.Count();
            var posts = PostConverter.Convert(await 
                (from pq in _context.Posts
                    where pq.Title.ToLower().Contains(name.ToLower())
                    // where pq.Title.ToLower() == name.ToLower()
                    select pq)
                .Skip(postCount - count * page)
                .Take(count)
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
                Count = postCount
            };
        }
        
        public async Task<PostList> GetByTagAsync(int tagId, int page, int count)
        {
            var postCount = _context.Posts.Count();
            var posts = PostConverter.Convert(
                await (from pq in _context.Posts
                    join pt in _context.PostTags on pq.Id equals pt.PostId
                    join t in _context.Tags on pt.TagId equals t.Id
                    where t.Id == tagId 
                    select pq)
                    .Skip(postCount - count * page)
                    .Take(count)
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