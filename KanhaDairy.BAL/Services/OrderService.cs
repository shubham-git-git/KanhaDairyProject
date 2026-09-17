using AutoMapper;
using KanhaDairy.BAL.DTOs.CartDTOs;
using KanhaDairy.BAL.DTOs.OrderDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Data;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Cart> _cartRepo;
        private readonly IGenericRepository<Item> _itemRepo;
        private readonly IGenericRepository<OrderItems> _orderItemRepo;
        private readonly KanhaDairyDbContext _kanhaDBContext;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<Cart> cartRepo, IGenericRepository<Item> itemRepo,
            IGenericRepository<OrderItems> orderItemRepo, KanhaDairyDbContext kanhaDBContext, IMapper mapper)
        {
            _kanhaDBContext = kanhaDBContext;
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
            _itemRepo = itemRepo;
            _orderItemRepo = orderItemRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateOrderDto createOrderDto)
        {
            if (createOrderDto == null)
            {
                throw new ArgumentNullException(nameof(createOrderDto));
            }
            using var transaction = await _kanhaDBContext.Database.BeginTransactionAsync();
            {
                try
                {
                    // 1. Get active cart items
                    var cartItems = await _cartRepo.FindAsync(c => c.FkUserId == createOrderDto.FkUserId && c.IsActive == true);
                    if (!cartItems.Any())
                    {
                        throw new KeyNotFoundException($"No cart items found for user with ID {createOrderDto.FkUserId}.");
                    }

                    decimal totalAmount = 0;

                    // 2. Validate stock
                    foreach (var cart in cartItems)
                    {
                        var item = await _itemRepo.SingleOrDefaultAsync(x => x.ItemId == cart.FkItemId);
                        if (item == null)
                            throw new Exception("Item not found");

                        if (item.Quantity < cart.Quantity)
                            throw new Exception($"{item.ItemName} out of stock");

                        totalAmount += cart.TotalPrice;
                    }
                    // 3. Create Order
                    var order = new Order
                    {
                        FkUserId = createOrderDto.FkUserId,
                        OrderDate = DateTime.Now,
                        TotalPrice = totalAmount,
                        FkOrderStatusId = 1, // Pending
                        PaymentStatus = false,
                        DeliveryDate = DateTime.Now.AddDays(3),
                        Comment = createOrderDto.Comment
                    };
                    //var Order = _mapper.Map<Order>(order);  /// use maping insert/create data in table creating new object of destination            
                    await _orderRepo.AddAsync(order);
                    //await _orderRepo.SaveAsync();

                    // 4. Create OrderItems and reduce stock
                    foreach (var cart in cartItems)
                    {
                        var orderItem = new OrderItems
                        {
                            FkOrder = order,
                            FkItemId = cart.FkItemId,
                            Quantity = cart.Quantity,
                            Price = cart.PricePerUnit,
                            FkDiscountId = cart.FkDiscountId
                        };
                        await _orderItemRepo.AddAsync(orderItem);

                        // 5. Reduce stock
                        var item = await _itemRepo
                            .SingleOrDefaultAsync(x => x.ItemId == cart.FkItemId);

                        item.Quantity -= cart.Quantity;
                        await _itemRepo.UpdateAsync(item);

                        // Clear cart
                        cart.IsActive = false; // ✅ better than delete
                        await _cartRepo.UpdateAsync(cart);
                    }
                    await _kanhaDBContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(); 
                    throw;
                }
            }
        }
        public async Task UpdateAsync(UpdateOrderDto updateOrderDto)
        {
            var existingOrder = await _orderRepo.GetByIdAsync(updateOrderDto.OrderId);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException($"Order with ID {updateOrderDto.OrderId} not found.");
            }
            _mapper.Map(updateOrderDto, existingOrder);  /// use maping update data in table using existing object of destination           
            await _orderRepo.UpdateAsync(existingOrder);
            await _orderRepo.SaveAsync();
        }
        public async Task DeleteAsync(DeleteOrderDto deleteOrderDto)
        {
            var existingOrder = await _orderRepo.GetByIdAsync(deleteOrderDto.OrderId);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException($"Order with ID {deleteOrderDto.OrderId} not found.");
            }
            _mapper.Map(deleteOrderDto, existingOrder);
            await _orderRepo.DeleteAsync(existingOrder);
            await _orderRepo.SaveAsync();
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var Order = await _orderRepo.GetByIdAsync(id);
            return _mapper.Map<OrderDto>(Order);
        }
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var Orders = await _orderRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(Orders);
        }
    }
}
