using ForYou.Application.Interfaces;
using ForYou.Domain.Entities;
using ForYou.Infrastructure.Repositories;
using ForYou.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
namespace ForYou.Infrastructure
{
    public class PostRepository : BaseRepository<PostEntity>, IPostRepository
    {

        protected readonly PostDbContext _dbContext;

        public PostRepository(PostDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PostEntity> OrderById(Guid id) => await ApplySpecification(new PostsBynameSpecification(id)).FirstOrDefaultAsync();

        private IQueryable<PostEntity> ApplySpecification(Specifcation<PostEntity> specification)
        {
            return SpecificationEvaluator.GetQuery(_dbContext.Set<PostEntity>(), specification);
        }

    }
}