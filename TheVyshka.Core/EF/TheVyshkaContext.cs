using TheVyshka.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheVyshka.Data.Entities;

namespace TheVyshka.Core.EF
{
    public class TheVyshkaContext: IdentityDbContext<User,
        IdentityRole<Guid>, Guid>
    {
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostPreview> PostPreviews { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<PostCollaborator> PostCollaborators { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        
        public TheVyshkaContext(DbContextOptions<TheVyshkaContext> opt): base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>[]
                {
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "editor",
                        NormalizedName = "EDITOR"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER"
                    }
                }    
            );
            builder.Entity<PostTag>().HasKey(u => new { u.PostId, u.TagId});
            builder.Entity<PostCollaborator>().HasKey(u => new { u.PostId, u.CollaboratorId});
            builder.Entity<PostPreview>().HasNoKey();


            base.OnModelCreating(builder);
        }
    }
}
