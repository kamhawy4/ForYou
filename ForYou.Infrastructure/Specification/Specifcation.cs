using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Specification
{
    public abstract class Specifcation<TEntity>  where TEntity : Entity
    {
        protected Specifcation(Expression<Func<TEntity, bool>>? criteria)
        =>   Criteria = criteria;

        public bool IsSplitQuery { get; protected set; }

        public Expression<Func<TEntity, bool>> Criteria { get;}

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new();

        public Expression<Func<TEntity, object>> OrderBy {  get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending {  get; private set; }

        protected void AddIncludes(Expression<Func<TEntity, object>> includeExpression) 
        { 
            Includes.Add(includeExpression); 
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> addOrderByDescendingexpression) =>  OrderByDescending = addOrderByDescendingexpression;
       

    }
}
