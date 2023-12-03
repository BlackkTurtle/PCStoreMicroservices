using DataAccess.DbContexts;
using DataAccess.Models;
using DataAccess.Repositories.Contracts;
namespace DataAccess.Repositories;

public class EFTypesRepository : EFGenericRepository<Types>, IEFTypesRepository
{
    public EFTypesRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }
    public override Task<Types> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
