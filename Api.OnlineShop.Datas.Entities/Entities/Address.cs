using System;
using System.Collections.Generic;

namespace Api.OnlineShop.Datas.Entities.Entities;

public partial class Address
{
    public int Id { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
