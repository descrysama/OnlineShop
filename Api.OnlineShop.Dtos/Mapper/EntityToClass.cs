﻿using System;
using Api.OnlineShop.Datas.Entities.Entities;

namespace Api.OnlineShop.Dtos.Mapper
{
	public static class EntityToClass
	{
		public static UserDto userTransform(User oldUser)
		{
			UserDto user = new UserDto()
			{
				Email = oldUser.Email,
				Password = oldUser.Password,
				AddressId = oldUser.AddressId
			};

			return user;
		}
	}
}
