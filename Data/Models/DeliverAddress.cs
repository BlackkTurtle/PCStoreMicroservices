using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class DeliverAddress
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string FullAddress { get; set; } = null!;
        public int DeliverOptionId { get; set; }
        public DeliverOption DeliverOption { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;


    }
}
