using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.OtherDTOs
{
    public class SearchBarResultDTO
    {
        public List<GetBrandDTO> Brands { get; set; }
        public List<CategoryIdNameDTO> Categorys { get; set; }
        public List<ProductIdNameDTO> Products { get; set; }
    }
}
