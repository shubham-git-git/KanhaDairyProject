using KanhaDairy.BAL.DTOs.ReturnDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IReturnService
    {
        Task CreateAsync(CreateReturnDto createReturnDto);
        Task UpdateAsync(UpdateReturnDto updateReturnDto);
        Task DeleteAsync(DeleteReturnDto deleteReturnDto);
        Task<ReturnDto> GetByIdAsync(int id);
        Task<IEnumerable<ReturnDto>> GetAllAsync();
    }
}
