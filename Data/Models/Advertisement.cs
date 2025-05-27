using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string PhotoLink { get; set; } = null!;
        public int Order { get; set; }
    }
}
