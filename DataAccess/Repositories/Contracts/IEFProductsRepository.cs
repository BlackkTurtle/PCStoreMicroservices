using DataAccess.Models;

namespace DataAccess.Repositories.Contracts;

public interface IEFProductsRepository : IEFGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByNameLikeAsync(string LikeName);
    Task<IEnumerable<Product>> GetProductsByBrandAsync(int BrandID);
    Task<IEnumerable<Product>> GetProductsByTypeAsync(int TypeID);
}