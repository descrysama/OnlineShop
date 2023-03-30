using System;
using Api.OnlineShop.Datas.Repository.Contract;
using Api.OnlineShop.Datas.Entities;

namespace Api.OnlineShop.Services
{
	public class UserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository repositoryUser)
		{
            _userRepository = repositoryUser;
		}


	}
}

