using System;
using Api.OnlineShop.Datas.Entities.Entities;

namespace Api.OnlineShop.Dtos
{
    public class OrderDto
	{
        public int Id { get; set; }

        public float Total { get; set; }

        public int UserId { get; set; }
    }
}

