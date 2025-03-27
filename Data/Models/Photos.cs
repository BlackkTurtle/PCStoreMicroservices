using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Photos
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string PhotoLink { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
