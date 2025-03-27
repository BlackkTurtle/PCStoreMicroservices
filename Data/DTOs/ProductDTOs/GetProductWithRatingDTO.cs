using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.ProductDTOs
{
    public class GetProductWithRatingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Rating { get; set; }
        public bool Availlability { get; set; }
        public string PhotoLink { get; set; } = null!;
        public double Price { get; set; }
    }
}
