﻿﻿using System;
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
            var posts = PostConverter.Convert(
                await _context.Posts.Skip(count * (page - 1)).Take(count).ToListAsync());
            foreach (var p in posts)
            {
                var tags = new List<TagsDto>();
                var postTags = _context.PostTags.
                    Where(t => t.PostId == p.Id).ToList();
                foreach (var t in postTags)
                {
                    tags.Add(TagConverter.Convert(await _context.Tags.
                        FirstOrDefaultAsync(u => u.Id == t.TagId)));
                }
                p.Tags = tags;
                
                var collaborators = new List<CollaboratorDto>();
                var postCollaborators = _context.
                    PostCollaborators.Where(c => c.PostId == p.Id).ToList();
                foreach (var c in postCollaborators)
                {
                    collaborators.Add(CollaboratorConverter.Convert(await _context.Collaborators.
                        FirstOrDefaultAsync(u => u.Id == c.CollaboratorId)));
                }
                p.Collaborators = collaborators;
            }
            return posts;
        }

        public async Task<PostDto> GetByIdAsync(Guid id)
        {
            var post = PostConverter.Convert(
                await _context.Posts.FindAsync(id));
            
            var tags = new List<TagsDto>();
            var postTags = _context.PostTags.
                Where(t => t.PostId == post.Id).ToList();
            foreach (var t in postTags)
            {
                tags.Add(TagConverter.Convert(await _context.Tags.
                    FirstOrDefaultAsync(u => u.Id == t.TagId)));
            }
            post.Tags = tags;
                
            var collaborators = new List<CollaboratorDto>();
            var postCollaborators = _context.PostCollaborators.
                Where(c => c.PostId == post.Id).ToList();
            foreach (var c in postCollaborators)
            {
                collaborators.Add(CollaboratorConverter.Convert(_context.Collaborators.
                    FirstOrDefault(u => u.Id == c.CollaboratorId)));
            }
            post.Collaborators = collaborators;
            
            return post;
        }
        
        public async Task<List<PostDto>> GetByRubricAsync(string rubric, int page, int count)
        {
            var posts = PostConverter.Convert(await 
                (from pq in _context.Posts
                    where pq.Rubric == rubric
                    select pq).Skip(count * (page - 1)).Take(count).ToListAsync());
            
            foreach (var p in posts)
            {
                var tags = new List<TagsDto>();
                var postTags = _context.PostTags.
                    Where(t => t.PostId == p.Id).ToList();
                foreach (var t in postTags)
                {
                    tags.Add(TagConverter.Convert(await _context.Tags.
                        FirstOrDefaultAsync(u => u.Id == t.TagId)));
                }
                p.Tags = tags;
                
                var collaborators = new List<CollaboratorDto>();
                var postCollaborators = _context.PostCollaborators.
                    Where(c => c.PostId == p.Id).ToList();
                foreach (var c in postCollaborators)
                {
                    collaborators.Add(CollaboratorConverter.Convert(await _context.Collaborators.
                        FirstOrDefaultAsync(u => u.Id == c.CollaboratorId)));
                }
                p.Collaborators = collaborators;
            }
            
            return posts;
        }
        
        public async Task<List<PostDto>> GetByCollaboratorAsync(string collaboratorName, int page, int count)
        {
            var posts = PostConverter.Convert(
                await (from pq in _context.Posts
                    join pc in _context.PostCollaborators on pq.Id equals pc.PostId
                    join c in _context.Collaborators on pc.CollaboratorId equals c.Id
                    where c.Name == collaboratorName
                    select pq).Skip(count * (page - 1)).Take(count).ToListAsync());
            foreach (var p in posts)
            {
                var tags = new List<TagsDto>();
                var postTags = _context.PostTags.
                    Where(t => t.PostId == p.Id).ToList();
                foreach (var t in postTags)
                {
                    tags.Add(TagConverter.Convert(await _context.Tags.
                        FirstOrDefaultAsync(u => u.Id == t.TagId)));
                }
                p.Tags = tags;
                
                var collaborators = new List<CollaboratorDto>();
                var postCollaborators = _context.PostCollaborators.
                    Where(c => c.PostId == p.Id).ToList();
                foreach (var c in postCollaborators)
                {
                    collaborators.Add(CollaboratorConverter.Convert(await _context.Collaborators.
                        FirstOrDefaultAsync(u => u.Id == c.CollaboratorId)));
                }
                p.Collaborators = collaborators;
            }
            
            // var collaboratorPosts = new List<PostDto>();
            // foreach (var post in posts)
            // {
            //     foreach (var collaborator in post.Collaborators)
            //     {
            //         if (collaborator.Name == collaboratorName)
            //         {
            //             collaboratorPosts.Add(post);
            //         }
            //     }
            // }
            
            return posts;
        }
        
        public async Task<List<PostDto>> GetByNameAsync(string name, int page, int count)
        {
            var posts = PostConverter.Convert(await 
                (from pq in _context.Posts
                    where pq.Title == name
                    select pq).Skip(count * (page - 1)).Take(count).ToListAsync());
            
            foreach (var p in posts)
            {
                var tags = new List<TagsDto>();
                var postTags = _context.PostTags.
                    Where(t => t.PostId == p.Id).ToList();
                foreach (var t in postTags)
                {
                    tags.Add(TagConverter.Convert(await _context.Tags.
                        FirstOrDefaultAsync(u => u.Id == t.TagId)));
                }
                p.Tags = tags;
                
                var collaborators = new List<CollaboratorDto>();
                var postCollaborators = _context.PostCollaborators.
                    Where(c => c.PostId == p.Id).ToList();
                foreach (var c in postCollaborators)
                {
                    collaborators.Add(CollaboratorConverter.Convert(await _context.Collaborators.
                        FirstOrDefaultAsync(u => u.Id == c.CollaboratorId)));
                }
                p.Collaborators = collaborators;
            }

            //posts = posts.Where(p => p.Title.Contains(name)).ToList();

            return posts;
        }
        
        public async Task<List<PostDto>> GetByTagAsync(string tagName, int page, int count)
        {
            var posts = PostConverter.Convert(
                await (from pq in _context.Posts
                    join pt in _context.PostTags on pq.Id equals pt.PostId
                    join t in _context.Tags on pt.TagId equals t.Id
                    where t.Name == tagName 
                    select pq).Skip(count * (page - 1)).Take(count).ToListAsync());
            
            foreach (var p in posts)
            {
                var tags = new List<TagsDto>();
                var postTags = _context.PostTags.
                    Where(t => t.PostId == p.Id).ToList();
                foreach (var t in postTags)
                {
                    tags.Add(TagConverter.Convert(await _context.Tags.
                        FirstOrDefaultAsync(u => u.Id == t.TagId)));
                }
                p.Tags = tags;
                
                var collaborators = new List<CollaboratorDto>();
                var postCollaborators = _context.PostCollaborators.
                    Where(c => c.PostId == p.Id).ToList();
                foreach (var c in postCollaborators)
                {
                    collaborators.Add(CollaboratorConverter.Convert(await _context.Collaborators.
                        FirstOrDefaultAsync(u => u.Id == c.CollaboratorId)));
                }
                p.Collaborators = collaborators;
            }
            
            // var tagPosts = new List<PostDto>();
            //
            // foreach (var post in posts)
            // {
            //     foreach (var collaborator in post.Tags)
            //     {
            //         if (collaborator.Name == tagName)
            //         {
            //             tagPosts.Add(post);
            //         }
            //     }
            // }
            
            return posts;
        }

        public async Task<PostDto> CreateAsync(PostDto item)
        {
            var post = _context.Posts.Add(
                PostConverter.Convert(item));
            
            if (item.Collaborators != null)
            {
                foreach (var collaborator in item.Collaborators)
                {
                    _context.PostCollaborators.Add(new PostCollaborator
                    {
                        PostId = item.Id,
                        CollaboratorId = collaborator.Id
                    });
                }
            }
            
            if (item.Tags != null)
            {
                foreach (var tag in item.Tags)
                {
                    _context.PostTags.Add(new PostTag
                    {
                        PostId = item.Id,
                        TagId = tag.Id
                    });
                }
            }

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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var post = await _context
                .Posts
                .FindAsync(id);
            if (post == null)
                return false;
            _context.Posts.Remove(post);
            foreach (var postTag in _context.PostTags)
            {
                if (postTag.PostId == post.Id)
                {
                    _context.Remove(postTag);
                }
            }
            foreach (var postCollaborator in _context.PostCollaborators)
            {
                if (postCollaborator.PostId == post.Id)
                {
                    _context.Remove(postCollaborator);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}