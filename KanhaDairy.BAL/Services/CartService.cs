using AutoMapper;
using KanhaDairy.BAL.DTOs.CartDTOs;
using KanhaDairy.BAL.Interfaces;
using KanhaDairy.DAL.Interfaces;
using KanhaDairy.MODEL.DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.Services
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Cart> _cartRepo;
        private readonly IGenericRepository<Item> _itemRepo;
        private readonly IGenericRepository<Discount> _discountRepo;
        private readonly IMapper _mapper;
        public CartService(IGenericRepository<Cart> genericRepo, IGenericRepository<Item> itemRepo, IGenericRepository<Discount> discountRepo, IMapper mapper)
        {
            _cartRepo = genericRepo;
            _itemRepo = itemRepo;
            _discountRepo = discountRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateCartDto createCartDto)
        {
            if (createCartDto == null)
            {
                throw new ArgumentNullException(nameof(createCartDto));
            }
                ///find item from item table to get price and calculate total price and also check if item exist or not            
                var item = await _itemRepo.SingleOrDefaultAsync(x=>x.ItemId == createCartDto.FkItemId);
                if (item == null)
                    throw new Exception("Item not found");

                var now = DateTime.Now;

                ///find discount from Discount table to get discount on item and also check if discount exist or not
                var discount = await _discountRepo.SingleOrDefaultAsync(x => x.FkItemId == createCartDto.FkItemId && x.IsActive == true &&
                (x.StartDate <= now) && ( x.EndDate >= now));

                var existingCart = await _cartRepo.FirstOrDefaultAsync(c => c.FkUserId == 3 && c.FkItemId == item.ItemId);
                if (existingCart != null)
                {
                    createCartDto.FkUserId = 3;
                    createCartDto.PricePerUnit = item.Price;
                    createCartDto.FkDiscountId = discount == null ? null : discount.DiscountId;
                    createCartDto.Quantity += existingCart.Quantity;
                    createCartDto.TotalPrice = createCartDto.Quantity * existingCart.PricePerUnit;
                    //var UpdateCart = _mapper.Map<Cart>(createCartDto);
                    var UpdateCart = _mapper.Map(createCartDto, existingCart);
                await _cartRepo.UpdateAsync(UpdateCart);
               
                }
                else
                {
                    createCartDto.FkUserId = 3;
                    createCartDto.PricePerUnit = item.Price;
                    createCartDto.FkDiscountId = discount == null ? null: discount.DiscountId;
                    createCartDto.TotalPrice = item.Price * createCartDto.Quantity;
                    var Cart = _mapper.Map<Cart>(createCartDto);  /// use maping insert/create data in table creating new object of destination            
                    await _cartRepo.AddAsync(Cart);
                }           
                await _cartRepo.SaveAsync();
        }
        public async Task UpdateAsync(UpdateCartDto updateCartDto)
        {
            var existingCart = await _cartRepo.SingleOrDefaultAsync(x =>x.FkUserId == 3 && x.FkItemId == updateCartDto.FkItemId);
            if (existingCart == null)
            {
                throw new KeyNotFoundException($"Item with ID {updateCartDto.FkItemId} not found.");
            }

            ///find item from item table to get price and calculate total price and also check if item exist or not            
            var item = await _itemRepo.SingleOrDefaultAsync(x => x.ItemId == updateCartDto.FkItemId);
            if (item == null)
                throw new Exception("Item not found");

            var now = DateTime.Now;

            ///find discount from Discount table to get discount on item and also check if discount exist or not
            var discount = await _discountRepo.SingleOrDefaultAsync(x => x.FkItemId == updateCartDto.FkItemId && x.IsActive == true &&
            (x.StartDate <= now) && (x.EndDate >= now));
            if (existingCart.Quantity >= 2)
            {
                updateCartDto.FkUserId = 3;
                updateCartDto.PricePerUnit = item.Price;
                updateCartDto.FkDiscountId = discount == null ? null : discount.DiscountId;
                updateCartDto.Quantity = existingCart.Quantity-1;
                updateCartDto.TotalPrice = item.Price * updateCartDto.Quantity;                
                var UpdateCart = _mapper.Map(updateCartDto, existingCart);
                await _cartRepo.UpdateAsync(UpdateCart);
            }
            else
            {
                _mapper.Map(updateCartDto, existingCart);
                await _cartRepo.DeleteAsync(existingCart);
            }
            await _cartRepo.SaveAsync();

        }
        public async Task DeleteAsync(DeleteCartDto deleteCartDto)
        {
            var existingCart = await _cartRepo.GetByIdAsync(deleteCartDto.FkUserId);
            if (existingCart == null)
            {
                throw new KeyNotFoundException($"Cart with user ID {deleteCartDto.FkUserId} not found.");
            }
            _mapper.Map(deleteCartDto, existingCart);
            await _cartRepo.DeleteAsync(existingCart);
            await _cartRepo.SaveAsync();
        }
        public async Task<CartDto> GetByIdAsync(int id)
        {
            var Cart = await _cartRepo.FirstOrDefaultAsync( x => x.FkUserId == id);
            return _mapper.Map<CartDto>(Cart);
        }
        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            var Carts = await _cartRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<CartDto>>(Carts);
        }
    }
}
