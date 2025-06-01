using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.OtherDTOs.CatalogDTOs
{
    public class CatalogSearchRequestDTO
    {
        [Required]
        public string SearchStr { get; set; }
        public int SortMethod { get; set; } = -1;
        public int CategoryId { get; set; } = 0;
        public List<int> BrandIds { get; set; }
        public List<CatalogCharacteristicWithProductCharacteristicDTO> CatalogCharacteristicWithProductCharacteristics { get; set; }
        [Required]
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 16;
        [Required]
        public double MinPrice { get; set; }
        [Required]
        public double MaxPrice { get; set; }
    }
}
