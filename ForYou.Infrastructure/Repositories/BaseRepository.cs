using ForYou.Application.Contracts;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;


namespace ForYou.Infrastructure.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {

        protected readonly PostDbContext _dbContext;

        public BaseRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();


        public async Task<T> AddAsync(T entity)
        {
           await  _dbContext.Set<T>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();
           return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
           _dbContext.Update(entity).State = EntityState.Modified;
           await _dbContext.SaveChangesAsync();
        }


    }
}
