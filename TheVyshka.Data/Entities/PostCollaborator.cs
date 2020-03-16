using System;

namespace TheVyshka.Data.Entities
{
    public class PostCollaborator
    {
        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string Role { get; set; }
    }
}