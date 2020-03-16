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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCollaborator> PostCollaborators { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        
        public TheVyshkaContext(DbContextOptions<TheVyshkaContext> opt): base(opt)
        {
            // Database.EnsureCreated();
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
                    }
                }    
            );
            builder.Entity<PostTag>()
                .HasKey(u => new { u.PostId, u.TagId});
            builder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTag)
                .HasForeignKey(pt => pt.PostId);
            builder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(c => c.PostTag)
                .HasForeignKey(pt => pt.TagId);
            
            builder.Entity<PostCollaborator>()
                .HasKey(u => new { u.PostId, u.CollaboratorId, u.Role});
            builder.Entity<PostCollaborator>()
                .HasOne(pc => pc.Post)
                .WithMany(p => p.PostCollaborator)
                .HasForeignKey(pc => pc.PostId);
            builder.Entity<PostCollaborator>()
                .HasOne(pc => pc.Collaborator)
                .WithMany(c => c.PostCollaborator)
                .HasForeignKey(pc => pc.CollaboratorId);
            
            builder.Entity<PostCategory>()
                .HasKey(u => new { u.PostId, u.CategoryId});
            builder.Entity<PostCategory>()
                .HasOne(pc => pc.Post)
                .WithMany(p => p.PostCategory)
                .HasForeignKey(pc => pc.PostId);
            builder.Entity<PostCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.PostCategory)
                .HasForeignKey(pc => pc.CategoryId);
            

            base.OnModelCreating(builder);
        }
    }
}
