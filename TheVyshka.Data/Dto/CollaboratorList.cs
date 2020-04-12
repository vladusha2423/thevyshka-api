using System.Collections.Generic;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Dto
{
    public class CollaboratorList
    {
        public int Count { get; set; }
        public List<CollaboratorDto> Collaborators { get; set; }
    }
}