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
    public class StorageRepository:GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(AppDbContext context) : base(context) { }
    }
}
