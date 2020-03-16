using System;
using System.Collections.Generic;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Dto
{
    public class CollaboratorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Links { get; set; }
        public List<PostDto> Posts { get; set; }

        public CollaboratorDto()
        {
            Posts = new List<PostDto>();
        }
    }
}