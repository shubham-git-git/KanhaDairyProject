using AutoMapper;
using KanhaDairy.BAL.DTOs.OrderItemDTOs;
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
    public class OrderItemService :IOrderItemService
    {
        private readonly IGenericRepository<OrderItems> _genericRepo;
        private readonly IMapper _mapper;
        public OrderItemService(IGenericRepository<OrderItems> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateOrderItemDto createOrderItemDto)
        {
            if (createOrderItemDto == null)
                throw new ArgumentNullException(nameof(createOrderItemDto));

            //var exists = await _genericRepo.AnyAsync(x => x.OrderItems.ToLower() == createOrderItemDto.OrderItemss.ToLower());
            //if (exists)
            //{
            //    throw new ConflictException("OrderItems already exists");
            //}
            var OrderItems = _mapper.Map<OrderItems>(createOrderItemDto);
            await _genericRepo.AddAsync(OrderItems);
            await _genericRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateOrderItemDto updateOrderItemDto)
        {
            var existingOrderItems = await _genericRepo.GetByIdAsync(updateOrderItemDto.FkOrderId);
            if (existingOrderItems == null)
            {
                throw new NotFoundException($"OrderItems with ID {updateOrderItemDto.FkOrderId} not found.");
            }
            _mapper.Map(updateOrderItemDto, existingOrderItems);  /// use maping update data in table using existing object of destination                       
            await _genericRepo.UpdateAsync(existingOrderItems);
            await _genericRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteOrderItemDto deleteOrderItemDto)
        {
            var existingOrderItems = await _genericRepo.GetByIdAsync(deleteOrderItemDto.OrderItemId);
            if (existingOrderItems == null)
            {
                throw new NotFoundException($"OrderItems with ID {deleteOrderItemDto.OrderItemId} not found.");
            }
            await _genericRepo.DeleteAsync(existingOrderItems);
            await _genericRepo.SaveAsync();
        }
        public async Task<OrderItemDto> GetByIdAsync(int id)
        {
            var OrderItems = await _genericRepo.GetByIdAsync(id);
            return _mapper.Map<OrderItemDto>(OrderItems);
        }
        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var OrderItems = await _genericRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemDto>>(OrderItems);
        }
    }
}
