using AutoMapper;
using KanhaDairy.BAL.DTOs.AddressDTOs;
using KanhaDairy.BAL.DTOs.BillingDTOs;
using KanhaDairy.BAL.DTOs.CartDTOs;
using KanhaDairy.BAL.DTOs.DiscountDTOs;
using KanhaDairy.BAL.DTOs.ItemCategoryDTOs;
using KanhaDairy.BAL.DTOs.ItemDTOs;
using KanhaDairy.BAL.DTOs.ItemPriceDTOs;
using KanhaDairy.BAL.DTOs.LogisticDTOs;
using KanhaDairy.BAL.DTOs.OrderDTOs;
using KanhaDairy.BAL.DTOs.OrderStatusDTOs;
using KanhaDairy.BAL.DTOs.PaymentDTOs;
using KanhaDairy.BAL.DTOs.PaymentModeDTOs;
using KanhaDairy.BAL.DTOs.PromotionDTOs;
using KanhaDairy.BAL.DTOs.RefreshTokenDTOs;
using KanhaDairy.BAL.DTOs.RefundDTOs;
using KanhaDairy.BAL.DTOs.ReturnDTOs;
using KanhaDairy.BAL.DTOs.RoleDTOs;
using KanhaDairy.BAL.DTOs.UnitDTOs;
using KanhaDairy.BAL.DTOs.UserDTOs;
using KanhaDairy.BAL.DTOs.UserLoginDTOs;
using KanhaDairy.BAL.DTOs.UserTypeDTOs;
using KanhaDairy.MODEL.DBEntities;

namespace KanhaDairyAPI.AutoMapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
                CreateMap<AddressDto, Address>().ReverseMap();  // Address mapping
                CreateMap<CreateAddressDto, Address>();
                CreateMap<UpdateAddressDto, Address>();
                CreateMap<DeleteAddressDto, Address>();
            //================================================================== 
                CreateMap<BillingDto, Billing>().ReverseMap();  // Billing mapping
                CreateMap<CreateBillingDto, Billing>();
                CreateMap<UpdateBillingDto, Billing>();
                CreateMap<DeleteBillingDto, Billing>();
            //================================================================== 
                CreateMap<CartDto, Cart>().ReverseMap();  // Cart mapping
                CreateMap<CreateCartDto, Cart>();
                CreateMap<UpdateCartDto, Cart>();
                CreateMap<DeleteCartDto, Cart>();
            //================================================================== 
                CreateMap<DiscountDto, Discount>().ReverseMap();  // Discount mapping
                CreateMap<CreateDiscountDto, Discount>();
                CreateMap<UpdateDiscountDto, Discount>();
                CreateMap<DeleteDiscountDto, Discount>();
            //===============================================================
                CreateMap<ItemCategoryDto, ItemCategory>().ReverseMap();  // ItemCategory mapping
                CreateMap<CreateItemCategoryDto, ItemCategory>();
                CreateMap<UpdateItemCategoryDto, ItemCategory>();
                CreateMap<DeleteItemCategoryDto, Item>();
            //==================================================================
                CreateMap<ItemDto, Item>().ReverseMap();  // Item mapping
                CreateMap<CreateItemDto, Item>();
                CreateMap<UpdateItemDto, Item>();
                CreateMap<DeleteItemDto, Item>();            
            //===============================================================
                CreateMap<ItemPriceDto, ItemPrice>().ReverseMap();  // ItemPrice mapping
                CreateMap<CreateItemPriceDto, ItemPrice>();
                CreateMap<UpdateItemPriceDto, ItemPrice>();
                CreateMap<DeleteItemPriceDto, ItemPrice>();
            //===============================================================                                                
                CreateMap<LogisticDto, Logistic>().ReverseMap();  // Logistic mapping
                CreateMap<CreateLogisticDto, Logistic>();
                CreateMap<UpdateLogisticDto, Logistic>();
                CreateMap<DeleteLogisticDto, Logistic>();
            //================================================================== 
                CreateMap<OrderDto, Order>().ReverseMap();  // Order mapping
                CreateMap<CreateOrderDto, Order>();
                CreateMap<UpdateOrderDto, Order>();
                CreateMap<DeleteOrderDto, Order>();
            //==================================================================
                CreateMap<OrderStatusDto, OrderStatus>().ReverseMap();  // OrderStatus mapping
                CreateMap<CreateOrderStatusDto, OrderStatus>();
                CreateMap<UpdateOrderStatusDto, OrderStatus>();
                CreateMap<DeleteOrderStatusDto, OrderStatus>();
            //==================================================================
                CreateMap<PaymentDto, Payment>().ReverseMap();  // Payment mapping
                CreateMap<CreatePaymentDto, Payment>();
                CreateMap<UpdatePaymentDto, Payment>();
                CreateMap<DeletePaymentDto, Payment>();
            //==================================================================
                CreateMap<PaymentModeDto, PaymentMode>().ReverseMap();  // PaymentMode mapping
                CreateMap<CreatePaymentModeDto, PaymentMode>();
                CreateMap<UpdatePaymentModeDto, PaymentMode>();
                CreateMap<DeletePaymentModeDto, PaymentMode>();
            //==================================================================
                CreateMap<PromotionDto, Promotion>().ReverseMap();  // Promotion mapping
                CreateMap<CreatePromotionDto, Promotion>();
                CreateMap<UpdatePromotionDto, Promotion>();
                CreateMap<DeletePromotionDto, Promotion>();
            //==================================================================
                CreateMap<RefreshTokenDto, RefreshToken>().ReverseMap();  // RefreshToken mapping
                CreateMap<CreateRefreshTokenDto, RefreshToken>();
                //CreateMap<UpdateRefreshTokenDto, RefreshToken>();
                //CreateMap<DeleteRefreshTokenDto, RefreshToken>();
            //==================================================================
                CreateMap<RefundDto, Refund>().ReverseMap();  // Refund mapping
                CreateMap<CreateRefundDto, Refund>();
                CreateMap<UpdateRefundDto, Refund>();
                CreateMap<DeleteRefundDto, Refund>();
            //==================================================================
                CreateMap<ReturnDto, Return>().ReverseMap();  // Return mapping
                CreateMap<CreateReturnDto, Return>();
                CreateMap<UpdateReturnDto, Return>();
                CreateMap<DeleteReturnDto, Return>();
            //==================================================================
                CreateMap<RoleDto, Role>().ReverseMap();  // Role mapping
                CreateMap<CreateRoleDto, Role>();
                CreateMap<UpdateRoleDto, Role>();
                CreateMap<DeleteRoleDto, Role>();
            //==================================================================
                CreateMap<UnitDto, Unit>().ReverseMap();  // Unit mapping
                CreateMap<CreateUnitDto, Unit>();
                CreateMap<UpdateUnitDto, Unit>();
                CreateMap<DeleteUnitDto, Unit>();
            //==================================================================  
                CreateMap<UserDto, User>().ReverseMap();  // User mapping
                CreateMap<CreateUserDto, User>();
                CreateMap<UpdateUserDto, User>();
                CreateMap<DeleteUserDto, User>();
            //================================================================== 
                CreateMap<UserLoginDto, UserLogin>().ReverseMap();  // UserLogin mapping
                CreateMap<CreateUserLoginDto, UserLogin>();
                CreateMap<UpdateUserLoginDto, UserLogin>();
                CreateMap<DeleteUserLoginDto, UserLogin>();
            //==================================================================
                CreateMap<UserTypeDto, UserType>().ReverseMap();  // UserType mapping
                CreateMap<CreateUserTypeDto, UserType>();
                CreateMap<UpdateUserTypeDto, UserType>();
                CreateMap<DeleteUserTypeDto, UserType>();
            //==================================================================
        }
    }
}
