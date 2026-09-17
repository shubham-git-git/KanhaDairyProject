using KanhaDairy.BAL.DTOs.CartDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCartDto createCartDto)
        {
            await _cartService.CreateAsync(createCartDto);
            return Ok(new
            {
                Status = true,
                Message = "Cart created successfully"
            });
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(int userId, [FromBody] UpdateCartDto updateCartDto)
        {
            if (updateCartDto.FkUserId != userId)
                throw new BadRequestException("User ID in the body does not match the ID in the route.");
            await _cartService.UpdateAsync(updateCartDto);
            return Ok(new
            {
                Status = true,
                Message = "Cart updated successfully"
            });
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(int userId, [FromBody] DeleteCartDto deleteCartDto)
        {
            if (deleteCartDto.FkUserId != userId)
                return BadRequest("Cart User ID in the body does not match the ID in the route.");
            await _cartService.DeleteAsync(deleteCartDto);

            return Ok(new
            {
                Status = true,
                Message = "Cart deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cart = await _cartService.GetAllAsync();
            if (cart == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Cart not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = cart
            });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(int userId)
        {
            var Cart = await _cartService.GetByIdAsync(userId);

            if (Cart == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Cart not found by user Id {userId}"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = Cart
            });
        }
    }
}
