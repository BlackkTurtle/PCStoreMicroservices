using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class ProductCharacteristics
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Linkable { get; set; }
        public int CharacteristicId { get; set; }
        public int ProductId { get; set; }
        public Characteristics Characteristic { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
