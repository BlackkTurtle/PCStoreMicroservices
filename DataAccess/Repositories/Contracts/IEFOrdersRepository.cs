using DataAccess.Models;

namespace DataAccess.Repositories.Contracts;

public interface IEFOrdersRepository : IEFGenericRepository<Order>
{
    Task<IEnumerable<Order>> GetAllOrdersByUserIDAsync(string userid);
}