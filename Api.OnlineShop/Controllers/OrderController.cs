using Microsoft.AspNetCore.Mvc;
using Api.OnlineShop.Services;
using Api.OnlineShop.Dtos;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Api.OnlineShop.Dtos.Mapper;
using Api.OnlineShop.Datas.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Api.OnlineShop.Utilities;

namespace Api.OnlineShop.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [Authorize]
    [HttpGet()]
    public async Task<IEnumerable<Order>> FindAll()
    {
        int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        IEnumerable<Order> order = await _orderService.FindAll(userId);

        return order;
    }

    [Authorize]
    [HttpPost()]
    public async Task<OrderDto> Create(CreateOrderDto orderToCreate)
    {
        int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        Order order = await _orderService.createOrder(orderToCreate, userId);

        return EntityToClass.orderTransform(order);
    }

}

