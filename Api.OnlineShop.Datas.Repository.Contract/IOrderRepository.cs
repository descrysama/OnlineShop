using System;
using Api.OnlineShop.Datas.Entities.Entities;

namespace Api.OnlineShop.Datas.Repository.Contract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> FindAllByUser(int UserId);
    }
}

