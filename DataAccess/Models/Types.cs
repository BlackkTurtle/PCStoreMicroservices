using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccess.Models;

public partial class Types
{
    public Types()
    {
        Products = new HashSet<Product>();
    }
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;
    [JsonIgnore]

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
