using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Count
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Quantity { get; set; }
        public ICollection<Payment> Payments { get; set; } = null!;
        public ICollection<CountOperation> FromCountOperations { get; set; } = null!;
        public ICollection<CountOperation> ToCountOperations { get; set; } = null!;
        public ICollection<CountManipulation> CountManipulations { get; set; } = null!;
    }
}
