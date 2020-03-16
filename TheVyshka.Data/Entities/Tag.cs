using System;
using System.Collections.Generic;

namespace TheVyshka.Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostTag> PostTag  { get; set; }
        public Tag()
        {
            PostTag = new List<PostTag>();
        }
    }
}