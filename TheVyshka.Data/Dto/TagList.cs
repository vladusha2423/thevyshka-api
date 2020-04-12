using System.Collections.Generic;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Dto
{
    public class TagList
    {
        public int Count { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}