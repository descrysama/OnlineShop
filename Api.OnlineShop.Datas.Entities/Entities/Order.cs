using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.OnlineShop.Datas.Entities.Entities;

public partial class Order
{
    public int Id { get; set; }

    public float Total { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    [JsonIgnore]
    public virtual User? User { get; set; }
}
