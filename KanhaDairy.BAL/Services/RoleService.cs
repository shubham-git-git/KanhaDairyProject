using AutoMapper;
using KanhaDairy.BAL.DTOs.RoleDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using KanhaDairy.UTILITY.Exceptions;


namespace KanhaDairy.BAL.Services
{
    public class RoleService:IRoleService
    {
        private readonly IGenericRepository<Role> _genericRepo;
        private readonly IMapper _mapper;
        public RoleService(IGenericRepository<Role> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateRoleDto createRoleDto)
        {
            if (createRoleDto == null)
                throw new ArgumentNullException(nameof(createRoleDto));

            var exists = await _genericRepo.AnyAsync(x => x.Roles.ToLower() == createRoleDto.Roles.ToLower());
            if (exists)
            {
                throw new ConflictException("Role already exists");
            }
            var role = _mapper.Map<Role>(createRoleDto);
            await _genericRepo.AddAsync(role);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateRoleDto updateRoleDto)
        {
            var existingRole = await _genericRepo.GetByIdAsync(updateRoleDto.RoleId);
            if (existingRole == null)
            {
                throw new NotFoundException($"Role with ID {updateRoleDto.RoleId} not found.");
            }
            _mapper.Map(updateRoleDto, existingRole);  /// use maping update data in table using existing object of destination           
            existingRole.ModifiedOn = DateTime.Now;
            await _genericRepo.UpdateAsync(existingRole);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteRoleDto deleteRoleDto)
        {
            var existingRole = await _genericRepo.GetByIdAsync(deleteRoleDto.RoleId);
            if (existingRole == null)
            {
                throw new NotFoundException($"Role with ID {deleteRoleDto.RoleId} not found.");
            }            
            await _genericRepo.DeleteAsync(existingRole);
            await _genericRepo.SaveAsync();
        }
        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var Role = await _genericRepo.GetByIdAsync(id);          
            return _mapper.Map<RoleDto>(Role);
        }
        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var Role = await _genericRepo.GetAllAsync();           
            return _mapper.Map<IEnumerable<RoleDto>>(Role);
        }
    }
}
