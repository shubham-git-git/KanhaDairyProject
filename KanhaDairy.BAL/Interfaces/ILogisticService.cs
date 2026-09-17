using KanhaDairy.BAL.DTOs.LogisticDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface ILogisticService
    {
        Task CreateAsync(CreateLogisticDto createLogisticDto);
        Task UpdateAsync(UpdateLogisticDto updateLogisticDto);
        Task DeleteAsync(DeleteLogisticDto deleteLogisticDto);
        Task<LogisticDto> GetByIdAsync(int id);
        Task<IEnumerable<LogisticDto>> GetAllAsync();
    }
}
