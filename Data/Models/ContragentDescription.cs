using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class ContragentDescription
    {
        public int Id { get; set; }
        public int ContragentId { get; set; }
        public string Description { get; set; } = null!;
        public Contragent Contragent { get; set; } = null!;
    }
}
