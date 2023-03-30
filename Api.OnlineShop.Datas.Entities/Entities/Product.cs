using System;
using System.Collections.Generic;

namespace Api.OnlineShop.Datas.Entities.Entities;

public partial class Product
{
    public int Id { get; set; }

    public float? Price { get; set; }

    public string? Image { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
}
