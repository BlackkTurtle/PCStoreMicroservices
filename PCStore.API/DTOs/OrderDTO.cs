using System;
using System.Collections.Generic;

namespace PCStoreService.API.DTOs;

public class OrderDTO
{
    public string email { get; set; } = null!;
    public string address { get; set; } = null!;
    public List<PartOrderDTO> partOrders { get; set; } = new List<PartOrderDTO>();
}
