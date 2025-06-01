using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.CategoryDTOs
{
    public class CategoryWithProductCountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoLink { get; set; }
        public int ProductsCount { get; set; }
    }
}
