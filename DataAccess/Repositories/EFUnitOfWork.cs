using System.Data;
using DataAccess.DbContexts;
using DataAccess.Repositories.Contracts;

namespace DataAccess.Repositories;

public class EFUnitOfWork : IEFUnitOfWork
{
    protected readonly PCStoreDbContext databaseContext;

    public IEFBrandsRepository eFBrandsRepository { get; }

    public IEFCommentsRepository eFCommentsRepository { get; }

    public IEFOrdersRepository eFOrdersRepository { get; }

    public IEFPartOrdersRepository eFPartOrdersRepository { get; }

    public IEFProductsRepository eFProductsRepository { get; }

    public IEFStatusesRepository eFStatusesRepository { get; }


    public IEFTypesRepository EFTypesRepository { get; }

    public EFUnitOfWork(
        PCStoreDbContext databaseContext,
        IEFBrandsRepository eFBrandsRepository,
        IEFCommentsRepository eFCommentsRepository,
        IEFOrdersRepository eFOrdersRepository,
        IEFPartOrdersRepository eFPartOrdersRepository,
        IEFProductsRepository eFProductsRepository,
        IEFStatusesRepository eFStatusesRepository,
        IEFTypesRepository eFTypesRepository)
    {
        this.databaseContext = databaseContext;
        EFTypesRepository = eFTypesRepository;
        this.eFBrandsRepository = eFBrandsRepository;
        this.eFProductsRepository = eFProductsRepository;
        this.eFPartOrdersRepository = eFPartOrdersRepository;
        this.eFCommentsRepository = eFCommentsRepository;
        this.eFOrdersRepository = eFOrdersRepository;
        this.eFStatusesRepository = eFStatusesRepository;
    }

    public async Task SaveChangesAsync()
    {
        await databaseContext.SaveChangesAsync();
    }
}