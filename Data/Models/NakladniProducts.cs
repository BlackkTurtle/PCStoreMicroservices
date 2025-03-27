using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class NakladniProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int NakladnaId { get; set; }
        public int ProductStorageId { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public Nakladni Nakladni { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public ProductStorages ProductStorage { get; set; } = null!;
    }
}
