using DataAccess.DbContexts;
using DataAccess.Models;
using DataAccess.Repositories.Contracts;

namespace DataAccess.Repositories;

public class EFBrandsRepository : EFGenericRepository<Brand>, IEFBrandsRepository
{
    public EFBrandsRepository(PCStoreDbContext databaseContext)
        : base(databaseContext)
    {
    }

    public override Task<Brand> GetCompleteEntityAsync(int id)
    {
        throw new NotImplementedException();
    }
}
