using MediaFlow.Business.Abstract;
using MediaFlow.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MediaFlow.WebServerSide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _userService.Register(registerDto);
            if (!result) return BadRequest("Username is already taken.");

            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.Login(loginDto);
            if (token == null) return Unauthorized("Invalid username or password.");

            return Ok(token);
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(int userId, [FromBody] ChangePasswordDto changePasswordDto)
        {
            var result = await _userService.ChangePassword(userId, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
            if (!result) return BadRequest("Old password is incorrect.");

            return Ok("Password updated successfully.");
        }
    }
}
