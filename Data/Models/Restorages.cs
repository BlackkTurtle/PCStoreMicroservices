using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Restorages
    {
        public int Id { get; set; }
        public DateTime RestorageDate { get; set; }
        public ICollection<ProductRestorage> ProductRestorages { get; set; } = null!;
    }
}
