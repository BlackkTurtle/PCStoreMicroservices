using DataAccess.Models;

namespace DataAccess.Repositories.Contracts;

public interface IEFPartOrdersRepository : IEFGenericRepository<PartOrder>
{
    Task<IEnumerable<PartOrder>> GetAllPartOrdersByOrderIDAsync(int orderid);
}