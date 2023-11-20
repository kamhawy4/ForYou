using ForYou.Application.Interfaces;
using ForYou.Domain.Entities;
using ForYou.Infrastructure.Repositories;
using System;
namespace ForYou.Infrastructure
{
    public class PostRepository : BaseRepository<PostEntity>, IPostRepository
    {
        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {

        }
    }
}