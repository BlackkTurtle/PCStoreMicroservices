using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Nakladni
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int ContragentId { get; set; }
        public int NakladnaTypeId { get; set; }
        public double Discount { get; set; }
        public NakladnaType NakladnaType { get; set; } = null!;
        public Contragent Contragent { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = null!;
        public ICollection<NakladniProducts> NakladniProducts { get; set; } = null!;
        public Order? Order { get; set; }

    }
}
