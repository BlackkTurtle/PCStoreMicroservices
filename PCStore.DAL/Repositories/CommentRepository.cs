using Microsoft.EntityFrameworkCore;
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
    public class CommentRepository:GenericRepository<Comment>, ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        {
            _context = context;
        }

        public async Task<double> GetRatingByProductId(int productId)
        {
            return await _context.Comments
                .Where(c => c.ProductId == productId)
                .AverageAsync(c => (double?)c.Rating) ?? 0.0;
        }
    }
}
