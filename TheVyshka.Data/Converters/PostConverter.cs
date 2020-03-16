﻿using System.Collections.Generic;
using System.Linq;
 using Microsoft.EntityFrameworkCore.Query.Internal;
 using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
 using TheVyshka.Data.Dto;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Converters
{
    public static class PostConverter
    {
        public static Post Convert(PostDto post)
        {
            return new Post
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                ViewType = post.ViewType,
                Date = post.Date,
                Status = post.LinkName,
                ModifiedDate = post.ModifiedDate,
                Image = post.Image,
                Podcast = post.Podcast,
                Content = post.Content,
                ViewCount = post.ViewCount
            };
        }
        
        public static PostDto Convert(Post post)
        {
            var tags = new List<TagDto>();
            if(post.PostTag!= null)
                foreach (var pt in post.PostTag)
                {
                    pt.Tag.PostTag = null;
                    tags.Add(TagConverter.Convert(pt.Tag));
                }

            var collabs = new List<CollaboratorDto>();
            if(post.PostCollaborator!=null)
                foreach (var pc in post.PostCollaborator)
                {
                    pc.Collaborator.PostCollaborator = null;
                    pc.Collaborator.Role = pc.Role;
                    collabs.Add(CollaboratorConverter.Convert(pc.Collaborator));
                }

            var cats = new List<Category>();
            if(post.PostCollaborator!=null)
                foreach (var pc in post.PostCategory)
                {
                    pc.Category.PostCategory = null;
                    cats.Add(pc.Category);
                }

            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                ViewType = post.ViewType,
                Date = post.Date,
                Status = post.Status,
                LinkName = post.LinkName,
                ModifiedDate = post.ModifiedDate,
                Image = post.Image,
                Podcast = post.Podcast,
                Content = post.Content,
                ViewCount = post.ViewCount,
                Tags = tags,
                Collaborators = collabs,
                Categories = cats
            };
        }

        public static List<Post> Convert(List<PostDto> posts)
        {
            return posts.Select(p => Convert(p)).ToList();
        }
        
        public static List<PostDto> Convert(List<Post> posts)
        {
            return posts.Select(p => Convert(p)).ToList();
        }
    }
}