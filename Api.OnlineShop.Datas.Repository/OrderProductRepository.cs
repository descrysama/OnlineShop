using System;
using Api.OnlineShop.Datas.Entities;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.OnlineShop.Datas.Repository
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(OnlineShopDbContext dbContext) : base(dbContext)
        {
        }

    }
}

