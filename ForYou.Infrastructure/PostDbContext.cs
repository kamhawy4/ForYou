using ForYou.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
       : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationship
            modelBuilder.Entity<CategoryEntity>()
                .HasMany(o => o.Posts)
                .WithOne(oi => oi.Category)
                .HasForeignKey(oi => oi.CategoryId);


            modelBuilder.Entity<UserEntity>()
               .HasMany(o => o.Posts)
               .WithOne(oi => oi.User)
               .HasForeignKey(oi => oi.AuthorId);


            modelBuilder.Entity<CommentEntity>()
               .HasOne(o => o.Posts);


        }




    }
}
