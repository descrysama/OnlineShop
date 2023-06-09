﻿using System;
using Api.OnlineShop.Datas.Entities;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Datas.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Api.OnlineShop.Datas.Repository
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
        public UserRepository(OnlineShopDbContext dbContext): base(dbContext)
        {
        }

        public async Task<User> FindOneByEmail(string id)
        {
            User type = await _table.FirstOrDefaultAsync(u => u.Email == id);
            Console.WriteLine(type);
            if (type == null)
            {
                return null;
            }
            else
            {
                return await _table.FirstOrDefaultAsync(u => u.Email == id);
            }
        }

    }
}

