using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace PCStoreService.API.DTOs;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string Adress { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public int StatusId { get; set; }
}
