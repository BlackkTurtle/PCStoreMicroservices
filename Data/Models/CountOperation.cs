using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class CountOperation
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int FromCountId { get; set; }
        public int ToCountId { get; set; }
        public double Quantity { get; set; }
        public string? Description { get; set; }
        public Count FromCount { get; set; } = null!;
        public Count ToCount { get; set; } = null!;
    }
}
