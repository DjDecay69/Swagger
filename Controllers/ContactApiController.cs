using EndPoint3.Models;
using EndPoint3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EndPoint3
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet("Users")]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser()
        {
            var response = await _userService.GetUsers();
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult<ServiceResponse<User>>> AddUser(AddUserDto user)
        {
            var response = await _userService.AddUserAsync(user);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ServiceResponse<User>>>UpdateUser(UpdateUserDto user)
        {
            var response = await _userService.UpdateUserAsync(user);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpDelete("DeleteUser")]
        public async Task<ActionResult<ServiceResponse<User>>>DeleteUser(DeleteUserDto user)
        {
            var response = await _userService.DeleteUserAsync(user);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
