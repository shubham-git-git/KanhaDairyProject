using KanhaDairy.BAL.DTOs.RoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IRoleService
    {
        Task CreateAsync(CreateRoleDto createRoleDto);
        Task UpdateAsync(UpdateRoleDto updateRoleDto);
        Task DeleteAsync(DeleteRoleDto deleteRoleDto);
        Task<RoleDto> GetByIdAsync(int id);
        Task<IEnumerable<RoleDto>> GetAllAsync();
    }
}
