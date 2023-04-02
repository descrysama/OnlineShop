using System;
using Api.OnlineShop.Datas.Repository.Contract;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Dtos;
using Api.OnlineShop.Dtos.Mapper;
using Api.OnlineShop.Datas.Repository;

namespace Api.OnlineShop.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IOrderProductRepository _orderProductRepository;

        private readonly IProductRepository _productRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderProductRepository orderProductRepository,
            IProductRepository productRepository
            )
        {
            _orderRepository = orderRepository;
            _orderProductRepository = orderProductRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> createOrder(CreateOrderDto OrderToCreate, int UserId)
        {

            Order order = await _orderRepository.Create(ClassToEntity.CreateOrder(OrderToCreate, UserId));

            List<OrderProductObject> orderObjects = OrderToCreate.ProductList;

            foreach(var orderobject in orderObjects)
            {
                Product product = await _productRepository.FindByKey(orderobject.ProductId);

                if(product != null)
                {
                    OrderProduct orderProduct = ClassToEntity.CreateOrderProduct(orderobject, order.Id);
                    await _orderProductRepository.Create(orderProduct);
                }
            }

            return order;
        }
      
        public async Task<IEnumerable<Order>> FindAll(int UserId)
        {

            return await _orderRepository.FindAllByUser(UserId);
        }
    }
}

