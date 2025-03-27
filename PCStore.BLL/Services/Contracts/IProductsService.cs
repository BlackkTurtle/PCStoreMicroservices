using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Services.Contracts
{
    public interface IProductsService
    {
        Task<IBaseResponse<List<GetProductWithRatingDTO>>> GetProductWithRatingDTOAsync();
        Task<IBaseResponse<List<GetProductWithRatingDTO>>> GetMultipleProductWithRatingDTOByIdAsync(int[] ints);
    }
}
