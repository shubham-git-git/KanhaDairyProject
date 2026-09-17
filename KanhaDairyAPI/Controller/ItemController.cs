using KanhaDairy.BAL.DTOs.ItemDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateItemDto createItemDto)
        {
            await _itemService.CreateAsync(createItemDto);
            return Ok(new
            {
                Status = true,
                Message = "Item created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateItemDto updateItemDto)
        {
            if (updateItemDto.ItemId != id)
                throw new BadRequestException("Item ID in the body does not match the ID in the route.");
            await _itemService.UpdateAsync(updateItemDto);
            return Ok(new
            {
                Status = true,
                Message = "Item updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteItemDto deleteItemDto)
        {
            if (deleteItemDto.ItemId != id)
                return BadRequest("Item ID in the body does not match the ID in the route.");
            await _itemService.DeleteAsync(deleteItemDto);

            return Ok(new
            {
                Status = true,
                Message = "Item deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Item = await _itemService.GetAllAsync();
            if (Item == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Item not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = Item
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Item = await _itemService.GetByIdAsync(id);

            if (Item == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Item not found by id {id}"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = Item
            });
        }
    }
}
