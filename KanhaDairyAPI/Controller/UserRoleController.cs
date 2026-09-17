//using KanhaDairy.BAL.Interfaces;
//using KanhaDairy.MODEL.Entities;
using KanhaDairy.BAL.DTOs.RoleDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public UserRoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRoleDto createRoleDto)
        {
            await _roleService.CreateAsync(createRoleDto);
            return Ok(new
            {
                Status = true,
                Message = "Role created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateRoleDto updateRoleDto)
        {
            if (updateRoleDto.RoleId != id)
                throw new BadRequestException("Role ID in the body does not match the ID in the route.");
            await _roleService.UpdateAsync(updateRoleDto);
            return Ok(new
            {
                Status = true,
                Message = "Role updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteRoleDto deleteRoleDto)
        {
            if (deleteRoleDto.RoleId != id)
                return BadRequest("Role ID in the body does not match the ID in the route.");
            await _roleService.DeleteAsync(deleteRoleDto);

            return Ok(new
            {
                Status = true,
                Message = "Role deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Role = await _roleService.GetAllAsync();
            if (Role == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Role not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = Role
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Role = await _roleService.GetByIdAsync(id);

            if (Role == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Role not found by id {id}"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = Role
            });
        }
    }
}
