using AspNetCore.ServiceRegistration.Dynamic;
using ForYou.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
