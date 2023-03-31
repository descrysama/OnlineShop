using System;
using Api.OnlineShop.Datas.Entities.Entities;

namespace Api.OnlineShop.Datas.Repository.Contract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> FindOneByEmail(string id);
    }
}

