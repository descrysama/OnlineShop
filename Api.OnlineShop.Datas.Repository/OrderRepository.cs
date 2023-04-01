using System;
using Api.OnlineShop.Datas.Entities;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.OnlineShop.Datas.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {

        protected readonly OnlineShopDbContext _dbContext;

        protected readonly DbSet<Order> _table;

        public OrderRepository(OnlineShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<Order>();
        }

        public async Task<IEnumerable<Order>> FindAllByUser(int UserId)
        {
            return await _table.Include(o => o.OrderProducts).Where(u => u.UserId == UserId).ToListAsync();
        }

  

    }
}

