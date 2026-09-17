using KanhaDairy.BAL.DTOs.UserDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto createUserDto)
        {
            await _userService.CreateAsync(createUserDto);
            return Ok(new
            {
                Status = true,
                Message = "User created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (updateUserDto.UserId != id)
                throw new BadRequestException("User ID in the body does not match the ID in the route.");
            await _userService.UpdateAsync(updateUserDto);
            return Ok(new
            {
                Status = true,
                Message = "User updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteUserDto deleteUserDto)
        {
            if (deleteUserDto.UserId != id)
                return BadRequest("User ID in the body does not match the ID in the route.");
            await _userService.DeleteAsync(deleteUserDto);

            return Ok(new
            {
                Status = true,
                Message = "User deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var User = await _userService.GetAllAsync();
            if (User == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "User not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = User
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var User = await _userService.GetByIdAsync(id);

            if (User == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "User not found by id"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = User
            });
        }
    }
}
