

using DataAccess.DbContexts;
using DataAccess.Models;
using DataAccess.Repositories.Contracts;

namespace DataAccess.Repositories;

public class EFStatusesRepository : EFGenericRepository<Status>, IEFStatusesRepository
{
    public EFStatusesRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override async Task<Status> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
