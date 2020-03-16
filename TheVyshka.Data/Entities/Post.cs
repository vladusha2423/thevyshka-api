using System;
using System.Collections.Generic;

namespace TheVyshka.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int WpId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public string ViewType { get; set; }
        public string LinkName { get; set; }
        public string Image { get; set; }
        public string Podcast { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public List<PostCollaborator> PostCollaborator { get; set; }
        public List<PostTag> PostTag { get; set; }
        public List<PostCategory> PostCategory{ get; set; }
        public Post()
        {
            PostCollaborator = new List<PostCollaborator>();
            PostTag = new List<PostTag>();
            PostCategory = new List<PostCategory>();
        }
    }
}