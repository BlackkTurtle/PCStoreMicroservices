﻿
using PCStore.DAL.Caching.RedisCache;
using PCStore.DAL.Persistence;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Repositories
{
    public class PaymentTypeRepository:GenericRepository<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(AppDbContext context, IRedisCacheService redisCacheService)
            : base(context, redisCacheService)
        {
        }
    }
}
