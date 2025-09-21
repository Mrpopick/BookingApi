using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomApi.Applications.Interfaces;
using RoomApi.Domain.Models;
using RoomApi.Domain.Models.Enums;

namespace RoomApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password) 
        {
            try 
            {
                var user = await _userService.LoggingAsync(username, password);
                return Ok(user);
            }
            catch (NotImplementedException) 
            {
                return BadRequest("User not find");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Reggister(string username, string password, Role role)
        {
            try
            {
                var user = await _userService.CreateUserAsync(username, password, role);
                return Ok(user);
            }
            catch (NotImplementedException) 
            {
                return BadRequest("User already exist!");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string username)
        {
            try
            {
                await _userService.DeleteUserAsync(username);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
