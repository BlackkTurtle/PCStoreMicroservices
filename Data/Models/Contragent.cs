using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Contragent
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ContragentDescription> ContragentDescriptions { get; set; } = null!;
        public ICollection<Nakladni> Nakladnis { get; set; } = null!;
    }
}
