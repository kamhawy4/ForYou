using ForYou.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForYou.Infrastructure
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
       : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostTagEntity> PostTag { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PostEntity>()
            .HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PostEntity>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentEntity>()
                .HasOne(c => c.Users)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentEntity>()
                .HasOne(c => c.Posts)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PostTagEntity>()
                .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTagEntity>()
                .HasOne(Pt => Pt.Post)
                .WithMany(pt => pt.PostTag)
                .HasForeignKey(pt =>pt.PostId);


            modelBuilder.Entity<PostTagEntity>()
                .HasOne(pt => pt.Tag)
                .WithMany(pt => pt.PostTag)
                .HasForeignKey(pt => pt.TagId);

        }

    }
}
