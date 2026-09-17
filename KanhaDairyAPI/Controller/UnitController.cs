using KanhaDairy.BAL.DTOs.UnitDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.BAL.Services;
using KanhaDairy.MODEL.DBEntities;
using KanhaDairy.UTILITY.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanhaDairyAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUnitDto createUnitDto)
        {           
            await _unitService.CreateAsync(createUnitDto);
            return Ok(new
            {
                Status = true,
                Message = "Unit created successfully"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUnitDto updateUnitDto)
        {
            if(updateUnitDto.UnitId != id)              
                throw new BadRequestException("Unit ID in the body does not match the ID in the route.");          
            await _unitService.UpdateAsync(updateUnitDto);
            return Ok(new
            {
                Status = true,
                Message = "Unit updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] DeleteUnitDto  deleteUnitDto)
        {
            if (deleteUnitDto.UnitId != id)
                return BadRequest("Unit ID in the body does not match the ID in the route.");
            await _unitService.DeleteAsync(deleteUnitDto);
           
            return Ok(new
            {
                Status = true,
                Message = "Unit deleted successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var unit= await _unitService.GetAllAsync();         
            if (unit == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Unit not found"
                });
            }

            return Ok(new
            {
                Status = true,
                Data = unit
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {         
            var unit = await _unitService.GetByIdAsync(id);

            if (unit == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "Unit not found by id"
                });
            }
            return Ok(new
            {
                Status = true,
                Data = unit
            });
        }
    }
}
