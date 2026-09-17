using KanhaDairy.BAL.DTOs.DiscountDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDiscountDto createDiscountDto)
        {
            await _discountService.CreateAsync(createDiscountDto);
            return Ok(new
            {
                Status = true,
                Message = "Discount created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateDiscountDto updateDiscountDto)
        {
            if (updateDiscountDto.DiscountId != id)
                throw new BadRequestException($"Discount ID in the body does not match the ID in the route.");
            await _discountService.UpdateAsync(updateDiscountDto);
            return Ok(new
            {
                Status = true,
                Message = "Discount updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteDiscountDto deleteDiscountDto)
        {
            if (deleteDiscountDto.DiscountId != id)
                return BadRequest("Discount ID in the body does not match the ID in the route.");
            await _discountService.DeleteAsync(deleteDiscountDto);

            return Ok(new
            {
                Status = true,
                Message = "Discount deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Discount = await _discountService.GetAllAsync();
            if (Discount == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Discount not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = Discount
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Discount = await _discountService.GetByIdAsync(id);

            if (Discount == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Discount not found by id {id}"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = Discount
            });
        }
    }
}
