using System;
using System.Collections.Generic;

namespace Api.OnlineShop.Datas.Entities.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
