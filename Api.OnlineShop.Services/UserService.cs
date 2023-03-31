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
        public async Task<List<UserDto>> FindAll()
        {

            var users = await _userRepository.FindAll().ConfigureAwait(false);

            List<UserDto> fetchedUsers = new();

            foreach(var user in users)
            {
                fetchedUsers.Add(EntityToClass.userTransform(user));
            }

            return fetchedUsers;

        }
    }
}

