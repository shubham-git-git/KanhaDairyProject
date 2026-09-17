using AutoMapper;
using KanhaDairy.BAL.DTOs.UnitDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using KanhaDairy.UTILITY.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Services
{
    public class UnitService : IUnitService
    {
        private readonly IGenericRepository<Unit> _genericRepo;
        private readonly IMapper _mapper;
        public UnitService(IGenericRepository<Unit> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateUnitDto createUnitDto)
        {
            if (createUnitDto == null)           
                throw new ArgumentNullException(nameof(createUnitDto));
           
            var exists = await _genericRepo.AnyAsync(x => x.UnitName.ToLower() == createUnitDto.UnitName.ToLower());            
            if (exists)
            {
                throw new ConflictException("Unit already exists");                
            }
            else
            {
                exists = await _genericRepo.AnyAsync(x => x.Abbreviation.ToLower() == createUnitDto.Abbreviation.ToLower());
                if (exists)
                    throw new ConflictException("Abbreviation(sort name) already exists");
            }
                

            var unit = _mapper.Map<Unit>(createUnitDto);           
            await _genericRepo.AddAsync(unit);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateUnitDto updateUnitDto)
        {
            var existingUnit = await _genericRepo.GetByIdAsync(updateUnitDto.UnitId);
            if (existingUnit == null)
            {
                throw new NotFoundException($"Unit with ID {updateUnitDto.UnitId} not found.");
            }                      
            _mapper.Map(updateUnitDto, existingUnit);  /// use maping update data in table using existing object of destination           
            existingUnit.ModifiedOn = DateTime.Now;
            await _genericRepo.UpdateAsync(existingUnit);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteUnitDto deleteUnitDto)
        {
            var existingUnit = await _genericRepo.GetByIdAsync(deleteUnitDto.UnitId);
            if (existingUnit == null)
            {
                throw new NotFoundException($"Unit with ID {deleteUnitDto.UnitId} not found.");
            }                      
            await _genericRepo.DeleteAsync(existingUnit);  
            await _genericRepo.SaveAsync();
        }            
        public async Task<UnitDto> GetByIdAsync(int id)
        {
            var unit = await _genericRepo.GetByIdAsync(id);
            if (unit == null)
                throw new NotFoundException($"Unit with ID {id} not found.");
            return _mapper.Map<UnitDto>(unit);
        }
        public async Task<IEnumerable<UnitDto>> GetAllAsync()
        {
            var unit = await _genericRepo.GetAllAsync();
            if(unit == null)
                throw new NotFoundException("Units not found.");
            return _mapper.Map<IEnumerable<UnitDto>>(unit);
        }
    }
}
