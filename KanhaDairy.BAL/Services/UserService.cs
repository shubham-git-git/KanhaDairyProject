using AutoMapper;
using KanhaDairy.BAL.DTOs.UserDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using KanhaDairy.UTILITY.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _genericRepo;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
                throw new ArgumentNullException(nameof(createUserDto));

            var exists = await _genericRepo.AnyAsync(x => x.UserName.ToLower() == createUserDto.UserName.ToLower());
            if (exists)
            {
                throw new ConflictException("User already exists");
            }            
            var user = _mapper.Map<User>(createUserDto);
            await _genericRepo.AddAsync(user);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateUserDto updateUserDto)
        {
            var existingUser = await _genericRepo.GetByIdAsync(updateUserDto.UserId);
            if (existingUser == null)
            {
                throw new NotFoundException($"User with ID {updateUserDto.UserId} not found.");
            }
            _mapper.Map(updateUserDto, existingUser);  /// use maping update data in table using existing object of destination                      
            await _genericRepo.UpdateAsync(existingUser);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteUserDto deleteUserDto)
        {
            var existingUser = await _genericRepo.GetByIdAsync(deleteUserDto.UserId);
            if (existingUser == null)
            {
                throw new NotFoundException($"User with ID {deleteUserDto.UserId} not found.");
            }         
            await _genericRepo.DeleteAsync(existingUser);
            await _genericRepo.SaveAsync();
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var User = await _genericRepo.GetByIdAsync(id);
            if (User == null)
                throw new NotFoundException($"User with ID {id} not found.");
            return _mapper.Map<UserDto>(User);
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var User = await _genericRepo.GetAllAsync();
            if (User == null)
                throw new NotFoundException("Users not found.");
            return _mapper.Map<IEnumerable<UserDto>>(User);
        }

    }
}
