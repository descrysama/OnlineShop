using System;
using Api.OnlineShop.Datas.Entities.Entities;

namespace Api.OnlineShop.Dtos.Mapper
{
	public class ClassToEntity
	{
        public static User CreateUser(createUserDto oldUser)
        {
            User user = new User()
            {
                Email = oldUser.Email,
                Password = oldUser.Password
            };

            return user;
        }
    }
}

