using KanhaDairy.BAL.DTOs.ReturnDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        private readonly IReturnService _returnService;
        public ReturnController(IReturnService returnService)
        {
            _returnService = returnService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateReturnDto createReturnDto)
        {
            await _returnService.CreateAsync(createReturnDto);
            return Ok(new
            {
                Status = true,
                Message = "Return created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateReturnDto updateReturnDto)
        {
            if (updateReturnDto.ReturnId != id)
                throw new BadRequestException("Return ID in the body does not match the ID in the route.");
            await _returnService.UpdateAsync(updateReturnDto);
            return Ok(new
            {
                Status = true,
                Message = "Return updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteReturnDto deleteReturnDto)
        {
            if (deleteReturnDto.ReturnId != id)
                return BadRequest("Return ID in the body does not match the ID in the route.");
            await _returnService.DeleteAsync(deleteReturnDto);

            return Ok(new
            {
                Status = true,
                Message = "Return deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Return = await _returnService.GetAllAsync();
            if (Return == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Return not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = Return
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Return = await _returnService.GetByIdAsync(id);

            if (Return == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Return not found by id {id}"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = Return
            });
        }
    }
}
