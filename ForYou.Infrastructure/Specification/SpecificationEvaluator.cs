using ForYou.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ForYou.Domain.Entities;

namespace ForYou.Infrastructure.Specification
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specifcation<TEntity> spec)  where TEntity : Entity
        {

            IQueryable<TEntity> query = inputQuery;


            if (spec.Criteria is not null)
            {
                query = (IQueryable<TEntity>)query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = (IQueryable<TEntity>)query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = (IQueryable<TEntity>)query.OrderByDescending(spec.OrderByDescending);
            }

            query = spec.Includes.Aggregate(query, (current, include) => (IQueryable<TEntity>)current.Include(include));


            if (spec.IsSplitQuery)
            {
                query.AsSplitQuery();
            }

            return query;
        }
    }
}
