using KanhaDairy.BAL.DTOs.DiscountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IDiscountService
    {
        Task CreateAsync(CreateDiscountDto createDiscountDto);
        Task UpdateAsync(UpdateDiscountDto updateDiscountDto);
        Task DeleteAsync(DeleteDiscountDto deleteDiscountDto);
        Task<DiscountDto> GetByIdAsync(int id);
        Task<IEnumerable<DiscountDto>> GetAllAsync();
    }
}
