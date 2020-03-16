using System;
using System.Collections.Generic;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Dto
{
    public class TagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostDto> Posts  { get; set; }

        public TagDto()
        {
            Posts = new List<PostDto>();
        }
    }
}