using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.OtherDTOs.CatalogDTOs
{
    public class CatalogCharacteristicWithProductCharacteristicDTO
    {
        public int CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }
        public List<string> ProductCharacteristicNames { get; set; }
    }
}
