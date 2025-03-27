using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Characteristics
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductCharacteristics> ProductCharacteristics { get; set; } = null!;
    }
}
