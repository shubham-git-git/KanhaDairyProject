using AutoMapper;
using KanhaDairy.BAL.DTOs.DiscountDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IGenericRepository<Discount> _genericRepo;
        private readonly IMapper _mapper;
        public DiscountService(IGenericRepository<Discount> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateDiscountDto createDiscountDto)
        {
            if (createDiscountDto == null)
            {
                throw new ArgumentNullException(nameof(createDiscountDto));
            }

            var discount = _mapper.Map<Discount>(createDiscountDto);  /// use maping insert/create data in table creating new object of destination            
            await _genericRepo.AddAsync(discount);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateDiscountDto updateDiscountDto)
        {
            var existingDiscount = await _genericRepo.GetByIdAsync(updateDiscountDto.DiscountId);
            if (existingDiscount == null)
            {
                throw new KeyNotFoundException($"Discount with ID {updateDiscountDto.DiscountId} not found.");
            }
            _mapper.Map(updateDiscountDto, existingDiscount);  /// use maping update data in table using existing object of destination           
            await _genericRepo.UpdateAsync(existingDiscount);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteDiscountDto deleteDiscountDto)
        {
            var existingDiscount = await _genericRepo.GetByIdAsync(deleteDiscountDto.DiscountId);
            if (existingDiscount == null)
            {
                throw new KeyNotFoundException($"Discount with ID {deleteDiscountDto.DiscountId} not found.");
            }
            _mapper.Map(deleteDiscountDto, existingDiscount);
            await _genericRepo.DeleteAsync(existingDiscount);
            await _genericRepo.SaveAsync();
        }
        public async Task<DiscountDto> GetByIdAsync(int id)
        {
            var Discount = await _genericRepo.GetByIdAsync(id);
            return _mapper.Map<DiscountDto>(Discount);
        }
        public async Task<IEnumerable<DiscountDto>> GetAllAsync()
        {
            var Discounts = await _genericRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<DiscountDto>>(Discounts);
        }
    }
}
