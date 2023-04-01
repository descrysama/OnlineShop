using System;
namespace Api.OnlineShop.Dtos;

	public class CreateOrderProductDto
	{
        public float OrderId { get; set; }

        public String? ProductId { get; set; }

        public int Amount { get; set; }
    }

