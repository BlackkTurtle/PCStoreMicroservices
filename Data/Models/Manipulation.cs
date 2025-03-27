using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Manipulation
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Operation { get; set; }
        public ICollection<CountManipulation> CountManipulations { get; set; } = null!;
    }
}
