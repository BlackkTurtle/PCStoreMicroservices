using System;
using System.Collections.Generic;

namespace PCStoreService.API.DTOs;

public partial class PartOrderDTO
{

    public int Article { get; set; }

    public int Quantity { get; set; }

    public float Price { get; set; }
}
