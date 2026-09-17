using KanhaDairy.BAL.DTOs.CartDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Interfaces
{
    public interface ICartService
    {
        Task CreateAsync(CreateCartDto createCartDto);
        Task UpdateAsync(UpdateCartDto updateCartDto);
        Task DeleteAsync(DeleteCartDto deleteCartDto);
        Task<CartDto> GetByIdAsync(int id);
        Task<IEnumerable<CartDto>> GetAllAsync();
    }
}
