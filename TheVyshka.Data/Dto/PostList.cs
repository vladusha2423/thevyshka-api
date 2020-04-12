using System.Collections.Generic;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Dto
{
    public class PostList
    {
        public int Count { get; set; }
        public List<PostDto> Posts { get; set; }
    }
}