using AutoMapper;
using KanhaDairy.BAL.DTOs.LogisticDTOs;
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
    public class LogisticService: ILogisticService
    {
        private readonly IGenericRepository<Logistic> _genericRepo;
        private readonly IMapper _mapper;
        public LogisticService(IGenericRepository<Logistic> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateLogisticDto createLogisticDto)
        {
            if (createLogisticDto == null)
            {
                throw new ArgumentNullException(nameof(createLogisticDto));
            }

            var Logistic = _mapper.Map<Logistic>(createLogisticDto);  /// use maping insert/create data in table creating new object of destination            
            await _genericRepo.AddAsync(Logistic);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateLogisticDto updateLogisticDto)
        {
            var existingLogistic = await _genericRepo.GetByIdAsync(updateLogisticDto.LogisticId);
            if (existingLogistic == null)
            {
                throw new KeyNotFoundException($"Logistic with ID {updateLogisticDto.LogisticId} not found.");
            }
            _mapper.Map(updateLogisticDto, existingLogistic);  /// use maping update data in table using existing object of destination           
            await _genericRepo.UpdateAsync(existingLogistic);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteLogisticDto deleteLogisticDto)
        {
            var existingLogistic = await _genericRepo.GetByIdAsync(deleteLogisticDto.LogisticId);
            if (existingLogistic == null)
            {
                throw new KeyNotFoundException($"Logistic with ID {deleteLogisticDto.LogisticId} not found.");
            }
            _mapper.Map(deleteLogisticDto, existingLogistic);
            await _genericRepo.DeleteAsync(existingLogistic);
            await _genericRepo.SaveAsync();
        }
        public async Task<LogisticDto> GetByIdAsync(int id)
        {
            var Logistic = await _genericRepo.GetByIdAsync(id);
            return _mapper.Map<LogisticDto>(Logistic);
        }
        public async Task<IEnumerable<LogisticDto>> GetAllAsync()
        {
            var Logistics = await _genericRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<LogisticDto>>(Logistics);
        }
    }
}
