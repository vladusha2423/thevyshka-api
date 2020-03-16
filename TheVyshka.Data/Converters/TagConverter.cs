﻿using System.Collections.Generic;
using System.Linq;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Converters
{
    public static class TagConverter
    {
        public static Tag Convert(TagDto tag)
        {
            return new Tag
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static TagDto Convert(Tag tag)
        {
            var posts = new List<PostDto>();
            if (tag.PostTag != null)
                foreach (var pt in tag.PostTag)
                {
                    pt.Post.PostTag = null;
                    pt.Post.PostCollaborator = null;
                    posts.Add(PostConverter.Convert(pt.Post));
                }
            
            return new TagDto
            {
                Id = tag.Id,
                Name = tag.Name,
                Posts = posts
            };
        }

        public static List<Tag> Convert(List<TagDto> Tag)
        {
            return Tag.Select(t => Convert(t)).ToList();
        }
        
        public static List<TagDto> Convert(List<Tag> Tag)
        {
            return Tag.Select(t => Convert(t)).ToList();
        }
    }
}