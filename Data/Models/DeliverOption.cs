using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class DeliverOption
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<DeliverAddress> DeliverAddresses { get; set; } = null!;

    }
}
