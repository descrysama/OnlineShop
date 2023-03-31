using Microsoft.AspNetCore.Mvc;
using Api.OnlineShop.Services;
using Api.OnlineShop.Dtos;
using Api.OnlineShop.Dtos.Mapper;
using Api.OnlineShop.Datas.Entities.Entities;
namespace Api.OnlineShop.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    private readonly AddressService _addressService;

    public UserController(UserService userService, AddressService addressService)
    {
        _userService = userService;
        _addressService = addressService;
    }

    [HttpPost()]
    public async Task<UserDto> Create(createUserDto newUser)
    {
        Address addressToCreate = new Address()
        {
            Street = newUser.Street,
            City = newUser.City,
            Country = newUser.Country
        };

        Address createdAddress = await _addressService.createAddress(addressToCreate).ConfigureAwait(false);

        User userToCreate = new User()
        {
            Email = newUser.Email,
            Password = newUser.Password,
            AddressId = createdAddress.Id
        };
        User createdUser = await _userService.createUser(userToCreate).ConfigureAwait(false);

        return EntityToClass.userTransform(createdUser);
    }
}

