using System;
using Api.OnlineShop.Datas.Repository.Contract;
using Api.OnlineShop.Datas.Entities.Entities;
using Api.OnlineShop.Dtos;
using Api.OnlineShop.Dtos.Mapper;

namespace Api.OnlineShop.Services
{
	public class UserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository repositoryUser)
		{
            _userRepository = repositoryUser;
		}

		public async Task<User> createUser(User userToCreate)
		{

            User user = await _userRepository.Create(userToCreate).ConfigureAwait(false);

            return user;

        }
	}
}

