using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.Infrastructure.Repositories;
using System;
namespace ForYou.Infrastructure
{
    public class CommentRepository : BaseRepository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}

