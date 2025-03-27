using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class ProductStorages
    {
        public int Id { get; set; }
        public int CharacteristicId { get; set; }
        public int ProductId { get; set; }
        public int StorageId { get; set; }
        public double Quantity { get; set; }
        public ICollection<ProductInventarization> ProductInventarizations { get; set; } = null!;
        public ICollection<NakladniProducts> NakladniProducts { get; set; } = null!;
        public ICollection<ProductRestorage> ProductRestorages { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public Storage Storage { get; set; } = null!;
    }
}
