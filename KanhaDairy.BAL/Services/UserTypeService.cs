using AutoMapper;
using KanhaDairy.BAL.DTOs.UserTypeDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using KanhaDairy.UTILITY.Exceptions;

namespace KanhaDairy.BAL.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IGenericRepository<UserType> _genericRepo;
        private readonly IMapper _mapper;
        public UserTypeService(IGenericRepository<UserType> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateUserTypeDto createUserTypeDto)
        {
            if (createUserTypeDto == null)
                throw new ArgumentNullException(nameof(createUserTypeDto));

            var exists = await _genericRepo.AnyAsync(x => x.UserTypeName.ToLower() == createUserTypeDto.UserTypeName.ToLower());
            if (exists)
            {
                throw new ConflictException("UserType already exists");
            }         
            var UserType = _mapper.Map<UserType>(createUserTypeDto);
            await _genericRepo.AddAsync(UserType);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateUserTypeDto updateUserTypeDto)
        {
            var existingUserType = await _genericRepo.GetByIdAsync(updateUserTypeDto.UserTypeId);
            if (existingUserType == null)
            {
                throw new NotFoundException($"UserType with ID {updateUserTypeDto.UserTypeId} not found.");
            }
            _mapper.Map(updateUserTypeDto, existingUserType);  /// use maping update data in table using existing object of destination           
            existingUserType.ModifiedOn = DateTime.Now;
            await _genericRepo.UpdateAsync(existingUserType);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteUserTypeDto deleteUserTypeDto)
        {
            var existingUserType = await _genericRepo.GetByIdAsync(deleteUserTypeDto.UserTypeId);
            if (existingUserType == null)
            {
                throw new NotFoundException($"UserType with ID {deleteUserTypeDto.UserTypeId} not found.");
            }        
            await _genericRepo.DeleteAsync(existingUserType);
            await _genericRepo.SaveAsync();
        }
        public async Task<UserTypeDto> GetByIdAsync(int id)
        {
            var UserType = await _genericRepo.GetByIdAsync(id);
            if (UserType == null)
                throw new NotFoundException($"UserType with ID {id} not found.");
            return _mapper.Map<UserTypeDto>(UserType);
        }
        public async Task<IEnumerable<UserTypeDto>> GetAllAsync()
        {
            var UserType = await _genericRepo.GetAllAsync();
            if (UserType == null)
                throw new NotFoundException("UserTypes not found.");
            return _mapper.Map<IEnumerable<UserTypeDto>>(UserType);
        }
    }
}
