using System;
using System.Collections.Generic;

namespace TheVyshka.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostCategory> PostCategory  { get; set; }
        public Category()
        {
            PostCategory = new List<PostCategory>();
        }
    }
}