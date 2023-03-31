using System;
namespace Api.OnlineShop.Dtos
{
	public class UpdateProductDto
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public String? Image { get; set; }

        public String? Description { get; set; }

        public int Quantity { get; set; }
    }
}

