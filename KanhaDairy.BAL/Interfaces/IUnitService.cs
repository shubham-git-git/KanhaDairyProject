using KanhaDairy.BAL.DTOs.UnitDTOs;
using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IUnitService
    {
        Task CreateAsync(CreateUnitDto createUnitDto);
        Task UpdateAsync(UpdateUnitDto updateUnitDto);
        Task DeleteAsync(DeleteUnitDto unitDto);
        Task<UnitDto> GetByIdAsync(int id);
        Task<IEnumerable<UnitDto>> GetAllAsync();
    }
}
