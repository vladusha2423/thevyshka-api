﻿using System.Collections.Generic;
using System.Linq;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Converters
{
    public static class CollaboratorConverter
    {
        public static Collaborator Convert(CollaboratorDto collaborator)
        {
            return new Collaborator
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                Role = collaborator.Role,
                Date = collaborator.Date,
                Description = collaborator.Description,
                Links = collaborator.Links
            };
        }

        public static CollaboratorDto Convert(Collaborator collaborator)
        {
            var posts = new List<PostDto>();
            if (collaborator.PostCollaborator != null)
            {
                foreach (var pc in collaborator.PostCollaborator)
                {
                    pc.Post.PostTag = null;
                    pc.Post.PostCollaborator = null;
                    pc.Post.PostCategory = null;
                    posts.Add(PostConverter.Convert(pc.Post));
                }
            }
            
            return new CollaboratorDto
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                Date = collaborator.Date,
                Role = collaborator.Role,
                Description = collaborator.Description,
                Links = collaborator.Links,
                Posts = posts
            };
        }

        public static List<Collaborator> Convert(List<CollaboratorDto> collaborators)
        {
            return collaborators.Select(c => Convert(c)).ToList();
        }
        
        public static List<CollaboratorDto> Convert(List<Collaborator> collaborators)
        {
            return collaborators.Select(c => Convert(c)).ToList();
        }
    }
}