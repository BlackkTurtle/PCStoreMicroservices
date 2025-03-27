using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class CountManipulation
    {
        public int Id { get; set; }
        public int CountId { get; set; }
        public int ManipulationId { get; set; }
        public double Quantity { get; set; }
        public Manipulation Manipulation { get; set; } = null!;
        public Count Count { get; set; } = null!;
    }
}
