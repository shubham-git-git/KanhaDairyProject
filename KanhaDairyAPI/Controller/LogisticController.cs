using KanhaDairy.BAL.DTOs.LogisticDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticController : ControllerBase
    {
        private readonly ILogisticService _logisticService;
        public LogisticController(ILogisticService logisticService)
        {
            _logisticService = logisticService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateLogisticDto createLogisticDto)
        {
            await _logisticService.CreateAsync(createLogisticDto);
            return Ok(new
            {
                Status = true,
                Message = "Logistic created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateLogisticDto updateLogisticDto)
        {
            if (updateLogisticDto.LogisticId != id)
                throw new BadRequestException("Logistic ID in the body does not match the ID in the route.");
            await _logisticService.UpdateAsync(updateLogisticDto);
            return Ok(new
            {
                Status = true,
                Message = "Logistic updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteLogisticDto deleteLogisticDto)
        {
            if (deleteLogisticDto.LogisticId != id)
                return BadRequest("Logistic ID in the body does not match the ID in the route.");
            await _logisticService.DeleteAsync(deleteLogisticDto);

            return Ok(new
            {
                Status = true,
                Message = "Logistic deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Logistic = await _logisticService.GetAllAsync();
            if (Logistic == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Logistic not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = Logistic
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Logistic = await _logisticService.GetByIdAsync(id);

            if (Logistic == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Logistic not found by id {id}"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = Logistic
            });
        }
    }
}
