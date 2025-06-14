﻿
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Repositories.Contracts
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<double>GetRatingByProductId(int productId);
        Task<bool> CheckIfCommentWithProductIdExist(int productId, int id);
    }
}
