using PCStore.DAL.Infrastructure.Interfaces;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Characteristics = PCStore.Data.Models.Characteristics;

namespace PCStore.DAL.Repositories.Contracts
{
    public interface ICharacteristicsRepository:IGenericRepository<Characteristics>
    {
    }
}
