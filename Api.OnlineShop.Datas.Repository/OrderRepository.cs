using System;
using Api.OnlineShop.Datas.Entities;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.OnlineShop.Datas.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineShopDbContext dbContext) : base(dbContext)
        {
        }



    }
}

