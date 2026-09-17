using KanhaDairy.BAL.DTOs.UserTypeDTOs;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IUserTypeService
    {
        Task CreateAsync(CreateUserTypeDto createUserTypeDto);
        Task UpdateAsync(UpdateUserTypeDto updateUserTypeDto);
        Task DeleteAsync(DeleteUserTypeDto deleteUserTypeDto);
        Task<UserTypeDto> GetByIdAsync(int id);
        Task<IEnumerable<UserTypeDto>> GetAllAsync();
    }
}
