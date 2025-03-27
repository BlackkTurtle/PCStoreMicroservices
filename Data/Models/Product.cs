using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<NakladniProducts> NakladniProducts { get; set; } = null!;
        public ICollection<ProductStorages> ProductStorages { get; set; } = null!;
        public ICollection<Photos> Photos { get; set; } = null!;
        public ICollection<ProductCharacteristics> ProductCharacteristics { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public Brand Brand { get; set; } = null!;
    }
}
