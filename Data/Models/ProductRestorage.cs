using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class ProductRestorage
    {
        public int Id { get; set; }
        public int RestorageId { get; set; }
        public int ProductStorageId { get; set; }
        public int FromStorageId { get; set; }
        public int ToStorageId { get; set; }
        public double Quantity { get; set; }
        public Restorages Restorages { get; set; } = null!;
        public ProductStorages ProductStorage { get; set; } = null!;
        public Storage FromStorage { get; set; } = null!;
        public Storage ToStorage { get; set; } = null!;
    }
}
