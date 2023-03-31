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

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost()]
    public async Task<User> Create(User newUser)
    {
        User createdUser = await _userService.createUser(newUser).ConfigureAwait(false);

        return createdUser;
    }
}

