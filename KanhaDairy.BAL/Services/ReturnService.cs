
using AutoMapper;
using KanhaDairy.BAL.DTOs.ReturnDTOs;
using KanhaDairy.BAL.DTOs.RoleDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using KanhaDairy.UTILITY.Exceptions;

namespace KanhaDairy.BAL.Services
{
    public class ReturnService : IReturnService
    {
        private readonly IGenericRepository<Return> _genericRepo;
        private readonly IMapper _mapper;
        public ReturnService(IGenericRepository<Return> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateReturnDto createReturnDto)
        {
            if (createReturnDto == null)
            {
                throw new ArgumentNullException(nameof(createReturnDto));
            }

            var returns = _mapper.Map<Return>(createReturnDto);  /// use maping insert/create data in table creating new object of destination            
            await _genericRepo.AddAsync(returns);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateReturnDto updateReturnDto)
        {
            var existingReturn = await _genericRepo.GetByIdAsync(updateReturnDto.ReturnId);
            if (existingReturn == null)
            {
                throw new KeyNotFoundException($"Return with ID {updateReturnDto.ReturnId} not found.");
            }
            _mapper.Map(updateReturnDto, existingReturn);  /// use maping update data in table using existing object of destination         
            await _genericRepo.UpdateAsync(existingReturn);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteReturnDto deleteReturnDto)
        {
            var existingReturn = await _genericRepo.GetByIdAsync(deleteReturnDto.ReturnId);
            if (existingReturn == null)
            {
                throw new KeyNotFoundException($"Return with ID {deleteReturnDto.ReturnId} not found.");
            }          
            _mapper.Map(deleteReturnDto, existingReturn);          
            await _genericRepo.DeleteAsync(existingReturn);
            await _genericRepo.SaveAsync();
        }
        public async Task<ReturnDto> GetByIdAsync(int id)
        {
            var returns = await _genericRepo.GetByIdAsync(id);                
            return _mapper.Map<ReturnDto>(returns);
        }
        public async Task<IEnumerable<ReturnDto>> GetAllAsync()
        {
            var returns = await _genericRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ReturnDto>>(returns);
        }
    }
}
