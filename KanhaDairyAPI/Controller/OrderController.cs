using KanhaDairy.BAL.DTOs.OrderDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderDto createOrderDto)
        {
            //var userIdFromToken = User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            //if (userIdFromToken == null)
            //{
            //    return Unauthorized(new
            //    {
            //        Status = false,
            //        Message = "User not authorized"
            //    });
            //}
            //createOrderDto.FkUserId = int.Parse(userIdFromToken);
            await _orderService.CreateAsync(createOrderDto);
            return Ok(new
            {
                Status = true,
                Message = "Order created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            if (updateOrderDto.OrderId != id)
                throw new BadRequestException("Order ID in the body does not match the ID in the route.");
            await _orderService.UpdateAsync(updateOrderDto);
            return Ok(new
            {
                Status = true,
                Message = "Order updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteOrderDto deleteOrderDto)
        {
            if (deleteOrderDto.OrderId != id)
                return BadRequest("Order ID in the body does not match the ID in the route.");
            await _orderService.DeleteAsync(deleteOrderDto);

            return Ok(new
            {
                Status = true,
                Message = "Order deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Order = await _orderService.GetAllAsync();
            if (Order == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Order not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = Order
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Order = await _orderService.GetByIdAsync(id);

            if (Order == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Order not found by id {id}"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = Order
            });
        }
    }
}
