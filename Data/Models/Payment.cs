using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int NakladnaId { get; set; }
        public int PaymentTypeId { get; set; }
        public int CountId { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }
        public Nakladni Nakladni { get; set; } = null!;
        public Count Count { get; set; } = null!;
        public PaymentType PaymentType { get; set; } = null!;
    }
}
