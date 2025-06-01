using MediatR;
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
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        {
            _context = context;
        }

        public async Task<Product> GetFullProductById(int id)
        {
            return await _context.Products
                .Include(x => x.Photos)
                .Include(x => x.Category).ThenInclude(c => c.Characteristics)
                .Include(x => x.Brand)
                .Include(x => x.Comments).ThenInclude(c => c.Children)
                .Include(x => x.ProductStorages)
                .Include(x => x.ProductCharacteristics).ThenInclude(pc => pc.Characteristic)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetLastNProductsWith1Photo(int n)
        {
            return await _context.Products
                .OrderByDescending(p => p.Id)
                .Take(n)
                .Include(x=>x.Photos.OrderBy(x=>x.Id).Take(1))
                .Include(x => x.Comments)
                .ToListAsync();
        }

        public async Task<List<Product>> GetMultipleById(int[] ints)
        {
            return await _context.Products
                     .Where(p => ints.Contains(p.Id))
                     .Include(x => x.Photos.OrderBy(photo => photo.Id).Take(1))
                     .Include(x => x.Comments)
                     .ToListAsync();
        }
    }
}
