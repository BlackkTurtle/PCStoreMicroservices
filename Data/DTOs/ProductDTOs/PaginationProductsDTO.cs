using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.ProductDTOs
{
    public class PaginationProductsDTO
    {
        public List<GetProductWithRatingDTO> Products { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
