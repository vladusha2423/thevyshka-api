using System.Collections.Generic;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PostDto> Posts  { get; set; }
        public CategoryDto()
        {
            Posts = new List<PostDto>();
        }
    }
}