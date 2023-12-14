using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccess.Models;

public partial class Product
{
    public Product()
    {
        Comments = new HashSet<Comment>();
        PartOrders = new HashSet<PartOrder>();
    }
    public int Article { get; set; }

    public string Name { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public int Type { get; set; }

    public float Price { get; set; }

    public string? ProductInfo { get; set; }

    public int BrandId { get; set; }

    public bool Availability { get; set; }
    [JsonIgnore]

    public virtual Brand Brand { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<PartOrder> PartOrders { get; } = new List<PartOrder>();
    [JsonIgnore]
    public virtual Types TypeNavigation { get; set; } = null!;
}
