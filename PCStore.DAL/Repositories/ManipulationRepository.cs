
using PCStore.DAL.Caching.RedisCache;
using PCStore.DAL.Persistence;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Repositories
{
    public class ManipulationRepository:GenericRepository<Manipulation>, IManipulationRepository
    {
        public ManipulationRepository(AppDbContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        {
        }
    }
}
