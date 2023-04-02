using System;
using Api.OnlineShop.Datas.Entities.Entities;

namespace Api.OnlineShop.Dtos
{

    public class OrderProductObject
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }


    public class CreateOrderDto
	{
        public float Total { get; set; }

        public virtual List<OrderProductObject> ProductList { get; set; }
    }
}

