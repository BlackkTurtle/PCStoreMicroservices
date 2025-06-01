using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.OtherDTOs.CatalogDTOs
{
    public class CatalogSearchResultDTO
    {
        public List<GetProductWithRatingDTO> Products { get; set; }
        public List<GetBrandDTO> Brands { get; set; }
        public List<CatalogCharacteristicWithProductCharacteristicDTO> catalogCharacteristicWithProductCharacteristics { get; set; }
        public List<CategoryWithProductCountDTO> categoryWithProductCountDTOs { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 16;
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public int TotalCount { get; set; }
    }
}
