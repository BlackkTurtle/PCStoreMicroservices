using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class ProductInventarization
    {
        public int InventarizationId { get; set; }
        public int ProductStorageId { get; set; }
        public double QuantityDiff { get; set; }
        public Inventarizations Inventarizations { get; set; } = null!;
        public ProductStorages ProductsStorage { get; set; } = null!;
    }
}
