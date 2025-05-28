using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PCStore.DAL.Caching.RedisCache;
using PCStore.DAL.Persistence;
using PCStore.DAL.Repositories.Contracts;
using PCStore.DAL.Specification;
using PCStore.DAL.Specification.Evaluator;

namespace PCStore.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly AppDbContext _dbContext;
        private readonly IRedisCacheService _redisCacheService;

        protected GenericRepository(AppDbContext context, IRedisCacheService redisCacheService = null!)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
            _redisCacheService = redisCacheService;
        }

        public T Create(T entity)
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var tmp = await _dbContext.Set<T>().AddAsync(entity);
            return tmp.Entity;
        }

        public Task CreateRangeAsync(IEnumerable<T> items)
        {
            return _dbContext.Set<T>().AddRangeAsync(items);
        }

        public EntityEntry<T> Update(T entity)
        {
            return _dbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> items)
        {
            _dbContext.Set<T>().UpdateRange(items);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> items)
        {
            _dbContext.Set<T>().RemoveRange(items);
        }

        public void Attach(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
        }

        public EntityEntry<T> Entry(T entity)
        {
            return _dbContext.Entry(entity);
        }

        public void Detach(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public Task ExecuteSqlRaw(string query)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(query);
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(IBaseSpecification<T, TResult> specification)
        {
            if (specification != null && specification.CacheKey != string.Empty)
            {
                var dataFromCache = await _redisCacheService.GetCachedDataAsync<IEnumerable<TResult>>(specification.CacheKey);
                if (dataFromCache != null)
                {
                    return dataFromCache;
                }

                var dataFromDb = ApplySpecificationForList(specification);

                var dataList = await dataFromDb.ToListAsync();

                if (!dataList.Any())
                {
                    return dataList;
                }

                await _redisCacheService.SetCachedDataAsync(specification.CacheKey, dataList, specification.CacheMinutes);

                return dataList;
            }
            else
            {
                return await ApplySpecificationForList(specification).ToListAsync();
            }
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(IBaseSpecification<T, TResult> specification)
        {
            if (specification != null && specification.CacheKey != string.Empty)
            {
                var dataFromCache = await _redisCacheService.GetCachedDataAsync<TResult>(specification.CacheKey);
                if (dataFromCache != null)
                {
                    return dataFromCache;
                }

                var dataFromDb = await ApplySpecificationForList(specification).FirstOrDefaultAsync();

                if (dataFromDb == null)
                {
                    return default!;
                }

                await _redisCacheService.SetCachedDataAsync(specification.CacheKey, dataFromDb, specification.CacheMinutes);

                return dataFromDb;
            }
            else
            {
                return await ApplySpecificationForList(specification).FirstOrDefaultAsync();
            }
        }

        private IQueryable<TResult> ApplySpecificationForList<TResult>(IBaseSpecification<T, TResult> specification)
        {
            return SpecificationEvaluator<T, TResult>.GetQuery(_dbSet.AsQueryable(), specification);
        }
    }
}