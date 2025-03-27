using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductStorages> ProductStorages { get; set; } = null!;
        public ICollection<ProductRestorage> FromProductRestorage { get; set; } = null!;
        public ICollection<ProductRestorage> ToProductRestorage { get; set; } = null!;
    }
}
