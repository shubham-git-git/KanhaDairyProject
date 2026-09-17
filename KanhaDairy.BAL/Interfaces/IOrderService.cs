using KanhaDairy.BAL.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderDto createOrderDto);
        Task UpdateAsync(UpdateOrderDto updateOrderDto);
        Task DeleteAsync(DeleteOrderDto deleteOrderDto);
        Task<OrderDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetAllAsync();
    }
}
