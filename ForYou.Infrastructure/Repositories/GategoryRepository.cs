using ForYou.Application.Contracts;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.Infrastructure.Repositories;
using System;
namespace ForYou.Infrastructure
{
    public class GategoryRepository : BaseRepository<CategoryEntity>, IGategoryRepository
    {
        public GategoryRepository(PostDbContext dbContext) : base(dbContext)
        {

        }
    }
}

