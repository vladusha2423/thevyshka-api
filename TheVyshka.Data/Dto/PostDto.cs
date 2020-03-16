using System;
using System.Collections.Generic;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ViewType { get; set; }
        public DateTime Date { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public string LinkName { get; set; }
        public string Image { get; set; }
        public string Podcast { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public List<CollaboratorDto> Collaborators { get; set; }
        public List<Category> Categories { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}