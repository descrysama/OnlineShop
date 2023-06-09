﻿using System;
using System.Collections.Generic;

namespace Api.OnlineShop.Datas.Entities.Entities;

public partial class OrderProduct
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}