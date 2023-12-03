using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace PCStoreService.API.DTOs;

public partial class PartOrderDTO
{
    public int PorderId { get; set; }

    public int Article { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }

    public float Price { get; set; }
}
