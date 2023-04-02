using System;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Dtos;
using Api.OnlineShop.Dtos.Mapper;

namespace Api.OnlineShop.Dtos.Mapper
{
	public class ClassToEntity
	{
        public static User CreateUser(createUserDto oldUser)
        {
            User user = new User()
            {
                Email = oldUser.Email,
                Password = oldUser.Password
            };

            return user;
        }

        public static Product CreateProduct(CreateProductDto oldProduct)
        {
            Product product = new Product()
            {
                Price = oldProduct.Price,
                Description = oldProduct.Description,
                Quantity = oldProduct.Quantity
            };

            return product;
        }

        public static Product UpdateProduct(UpdateProductDto oldProduct)
        {
            Product product = new Product()
            {
                Id = oldProduct.Id,
                Price = oldProduct.Price,
                Description = oldProduct.Description,
                Quantity = oldProduct.Quantity
            };

            return product;
        }
        
        public static Order CreateOrder(CreateOrderDto oldOrder, int Id)
        {
            Order order = new Order()
            {
                Total = oldOrder.Total,
                UserId = Id
            };

            return order;
        }

        public static OrderProduct CreateOrderProduct(OrderProductObject orderProductObject, int Id)
        {
            OrderProduct orderProduct = new OrderProduct()
            {
                ProductId = orderProductObject.ProductId,
                OrderId = Id,
                Amount = orderProductObject.Amount
            };

            return orderProduct;
        }

    }
}

