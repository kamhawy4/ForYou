using ForYou.Application.Contracts;
using ForYou.Domain.Entities;
using ForYou.Infrastructure.Repositories;
using System;
namespace ForYou.Infrastructure
{
    public class CommentRepository<T> : BaseRepository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(PostDbContext dbContext) : base(dbContext)
        {
        }
    }
}

