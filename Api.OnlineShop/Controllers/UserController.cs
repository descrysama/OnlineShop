using Microsoft.AspNetCore.Mvc;
using Api.OnlineShop.Services;
using Api.OnlineShop.Dtos;
using Api.OnlineShop.Dtos.Mapper;
using Api.OnlineShop.Datas.Entities.Entities;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Api.OnlineShop.Utilities;

namespace Api.OnlineShop.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    private readonly AddressService _addressService;

    private readonly IConfiguration _configuration;

    public UserController(UserService userService, AddressService addressService, IConfiguration configuration)
    {
        _userService = userService;
        _addressService = addressService;
        _configuration = configuration;
    }

    [HttpPost("signup")]
    public async Task<UserDto> SignUp(createUserDto newUser)
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

        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.UtcNow.AddDays(7),
            Path = "/",
            Secure = true,
            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
        };

        Response.Cookies.Append("_auth", JwtGenerator.GenerateJwtToken(createdUser.Id.ToString(), createdUser.Email, _configuration), cookieOptions);
        return EntityToClass.userTransform(createdUser);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn(loginUserDto newUser)
    {
        User user = await _userService.FindOne(newUser.Email.ToString()).ConfigureAwait(false);

        if(user == null)
        {
            return BadRequest("Email ou mot de passe incorrect");
        }

        if(newUser.Password.Equals(user.Password))
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(7),
                Path = "/",
                Secure = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict
            };

            Response.Cookies.Append("_auth", JwtGenerator.GenerateJwtToken(user.Id.ToString(), user.Email, _configuration), cookieOptions);

            return Ok(EntityToClass.userTransform(user));
        } else
        {
            return BadRequest("Email ou mot de passe incorrect");
        }

        
    }

    [Authorize]
    [HttpGet("all")]
    public async Task<IEnumerable<UserDto>> GetAll()
    {
        List<UserDto> allUsers = await _userService.FindAll().ConfigureAwait(false);

        if(allUsers != null)
        {
            return allUsers;
        } else
        {
            return null;
        }
    }
}

