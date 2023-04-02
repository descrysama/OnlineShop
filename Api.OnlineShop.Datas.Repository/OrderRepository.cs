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
            return await _table.Include(o => o.OrderProducts).ThenInclude(op => op.Product).Where(u => u.UserId == UserId).ToListAsync();

            return await _table.Include(o => o.OrderProducts).Select(o => new Order
            {
                Id = o.Id,
                Total = o.Total,
                UserId = o.UserId,
                OrderProducts = o.OrderProducts.Select(op => new OrderProduct
                {
                    Id = op.Id,
                    Amount = op.Amount,
                    Product = new Product
                    {
                        Id = op.Product.Id,
                        Price = op.Product.Price,
                        Image = op.Product.Image,
                        Description = op.Product.Description,
                        Quantity = op.Product.Quantity
                    }
                }).ToList()
            }).Where(u => u.UserId == UserId).ToListAsync();
        }

  

    }
}

