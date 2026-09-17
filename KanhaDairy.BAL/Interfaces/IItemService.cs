using KanhaDairy.BAL.DTOs.ItemDTOs;
using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IItemService
    {
        Task CreateAsync(CreateItemDto createItemDto);
        Task UpdateAsync(UpdateItemDto updateItemDto);
        Task DeleteAsync(DeleteItemDto deleteItemDto);
        Task<ItemDto> GetByIdAsync(int id);
        Task<IEnumerable<ItemDto>> GetAllAsync();
    }
}
