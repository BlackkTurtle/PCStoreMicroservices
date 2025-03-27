using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Inventarizations
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<ProductInventarization> ProductInventarizations { get; set; } = null!;
    }
}
