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
    public class ProductStoragesRepository:GenericRepository<ProductStorages>, IProductStoragesRepository
    {
        private readonly AppDbContext _context;
        public ProductStoragesRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<bool> CheckAvaillabilityByProductId(int productId)
        {
            return await _context.ProductStorages.AnyAsync(p => p.ProductId == productId && p.Quantity > 0);
        }
    }
}
