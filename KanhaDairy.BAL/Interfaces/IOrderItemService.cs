using KanhaDairy.BAL.DTOs.OrderDTOs;
using KanhaDairy.BAL.DTOs.OrderItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IOrderItemService
    {
        Task CreateAsync(CreateOrderItemDto createOrderDto);
        Task UpdateAsync(UpdateOrderItemDto updateOrderDto);
        Task DeleteAsync(DeleteOrderItemDto deleteOrderDto);
        Task<OrderItemDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderItemDto>> GetAllAsync();
    }
}
