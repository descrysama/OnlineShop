using System;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.OnlineShop.Datas.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
        public UserRepository(DbContext dbContext): base(dbContext)
        {
        }

    }
}

