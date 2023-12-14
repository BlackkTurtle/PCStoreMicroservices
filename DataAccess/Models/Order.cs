using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccess.Models;

public partial class Order
{
    public Order()
    {
        PartOrders = new HashSet<PartOrder>();
    }
    public int OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string Adress { get; set; } = null!;

    public string UserId { get; set; }=null!;

    public int StatusId { get; set; }
    [JsonIgnore]

    public virtual ICollection<PartOrder> PartOrders { get; } = new List<PartOrder>();
    [JsonIgnore]
    public virtual Status Status { get; set; } = null!;
}
