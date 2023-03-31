using System;
namespace Api.OnlineShop.Dtos
{
	public class ProductDto
    {
        public float? Price { get; set; }

        public String? Image { get; set; }

        public String? Description { get; set; }

        public int? Quantity { get; set; }
    }
}

