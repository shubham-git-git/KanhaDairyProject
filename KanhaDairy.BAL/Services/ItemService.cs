using AutoMapper;
using KanhaDairy.BAL.DTOs.ItemDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.DAL.Repositories;
using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Services
{
    public class ItemService : IItemService
    {
        private readonly IGenericRepository<Item> _genericRepo;
        private readonly IMapper _mapper;
        public ItemService(IGenericRepository<Item> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateItemDto  createItemDto)
        {
            if (createItemDto == null)
            {
                throw new ArgumentNullException(nameof(createItemDto));
            }

            var item = _mapper.Map<Item>(createItemDto);  /// use maping insert/create data in table creating new object of destination             
            await _genericRepo.AddAsync(item);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateItemDto updateItemDto)
        {
            var existingItem = await _genericRepo.GetByIdAsync(updateItemDto.ItemId);
            if (existingItem == null)
            {
                throw new KeyNotFoundException($"Item with ID {updateItemDto.ItemId} not found.");
            }           
            _mapper.Map(updateItemDto, existingItem);  /// use maping update data in table using existing object of destination           
            await _genericRepo.UpdateAsync(existingItem);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteItemDto deleteItemDto)
        {
            var existingItem = await _genericRepo.GetByIdAsync(deleteItemDto.ItemId);
            if (existingItem == null)
            {
                throw new KeyNotFoundException($"Item with ID {deleteItemDto.ItemId} not found.");
            }           
            _mapper.Map(deleteItemDto, existingItem);
            await _genericRepo.DeleteAsync(existingItem);
            await _genericRepo.SaveAsync();
        }
        public async Task<ItemDto> GetByIdAsync(int id)
        {
            var item = await _genericRepo.GetByIdAsync(id);
            return _mapper.Map<ItemDto>(item);
        }
        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _genericRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }


    }
}
