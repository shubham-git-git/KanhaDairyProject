
using KanhaDairy.BAL.DTOs.UserTypeDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;

using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;
        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserTypeDto createUserTypeDto)
        {
            await _userTypeService.CreateAsync(createUserTypeDto);
            return Ok(new
            {
                Status = true,
                Message = "UserType created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserTypeDto updateUserTypeDto)
        {
            if (updateUserTypeDto.UserTypeId != id)
                throw new BadRequestException("UserType ID in the body does not match the ID in the route.");
            await _userTypeService.UpdateAsync(updateUserTypeDto);
            return Ok(new
            {
                Status = true,
                Message = "UserType updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteUserTypeDto deleteUserTypeDto)
        {
            if (deleteUserTypeDto.UserTypeId != id)
                return BadRequest("UserType ID in the body does not match the ID in the route.");
            await _userTypeService.DeleteAsync(deleteUserTypeDto);

            return Ok(new
            {
                Status = true,
                Message = "UserType deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var UserType = await _userTypeService.GetAllAsync();
            if (UserType == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "UserType not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = UserType
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var UserType = await _userTypeService.GetByIdAsync(id);

            if (UserType == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "UserType not found by id"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = UserType
            });
        }
    }
}
