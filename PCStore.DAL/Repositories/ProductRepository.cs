using Microsoft.EntityFrameworkCore;
using PCStore.DAL.Infrastructure;
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
        public ProductRepository(AppDbContext context) : base(context) 
        {
            this._context = context;
        }

        public async Task<List<Product>> GetLastNProductsWith1Photo(int n)
        {
            return await _context.Products.OrderByDescending(p => p.Id).Take(n).Include(x=>x.Photos.OrderBy(x=>x.Id).Take(1)).ToListAsync();
        }

        public async Task<List<Product>> GetMultipleById(int[] ints)
        {
            return await _context.Products
                     .Where(p => ints.Contains(p.Id))
                     .Include(x => x.Photos.OrderBy(photo => photo.Id).Take(1))
                     .ToListAsync();
        }
    }
}
