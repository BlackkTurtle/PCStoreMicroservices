

using PCStore.Data.Models;

namespace PCStore.API.DTOs
{
    public class GetProductsByTypesAndBrands
    {
        public List<Brand> Brands { get; set; } = null!;
        public List<Category> Categories { get; set; } = null!;
        public double minPrice { get; set; }
        public double maxPrice { get; set;}
    }
}
