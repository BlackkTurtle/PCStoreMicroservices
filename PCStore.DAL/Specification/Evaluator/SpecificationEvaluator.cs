using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PCStore.DAL.Specification.Evaluator
{
    public static class SpecificationEvaluator<T, TResult>
    where T : class
    {
        public static IQueryable<TResult> GetQuery(IQueryable<T> inputQuery, IBaseSpecification<T, TResult> specification)
        {
            var query = inputQuery;

            if (specification.Predicate != null)
            {
                query = query.Where(specification.Predicate);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip.Value).Take(specification.Take.Value);
            }

            if(specification.Selector == null)
            {
                return (IQueryable<TResult>)query;
            }

            return query.Select(specification.Selector);
        }
    }
}
