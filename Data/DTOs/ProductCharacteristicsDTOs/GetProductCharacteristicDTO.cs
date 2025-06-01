using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.ProductCharacteristicsDTOs
{
    public class GetProductCharacteristicDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }
        public bool Linkable { get; set; }
    }
}
