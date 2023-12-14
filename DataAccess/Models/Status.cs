using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccess.Models;

public partial class Status
{
    public Status()
    {
        Orders = new HashSet<Order>();
    }
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;
    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
