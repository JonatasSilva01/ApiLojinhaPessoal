using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrimeiroInfluencer.Data;
using PrimeiroInfluencer.Data.DTOs.user;
using PrimeiroInfluencer.Services;

namespace PrimeiroInfluencer.Controllers
{
    public class UserController : ControllerBase
    {
        private UserServices _userServices;

        public UserController(UserServices userContext) 
        {
            _userServices = userContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            await _userServices.RegisterAsync(dto);
            return Ok("User created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDto dto)
        {
            var token = await _userServices.LoginAsync(dto);
            return Ok(token);
        }
    }
}
