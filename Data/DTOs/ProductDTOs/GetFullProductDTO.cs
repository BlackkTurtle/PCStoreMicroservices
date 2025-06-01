using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.DTOs.CommentDTOs;
using PCStore.Data.DTOs.ProductCharacteristicsDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.ProductDTOs
{
    public class GetFullProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; }
        public CategoryIdNameDTO CategoryIdNameDTO { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Rating { get; set; }
        public bool Availlability { get; set; }
        public List<GetCommentDTO> Comments { get; set; }
        public List<GetReviewDTO> Reviews { get; set; }
        public List<GetProductCharacteristicDTO> ProductCharacteristics { get; set; }
    }
}
