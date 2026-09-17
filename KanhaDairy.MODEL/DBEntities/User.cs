using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class User : SoftDeleteEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? CountryCode { get; set; }
        public string Mobile { get; set; } = null!;
        public int FkRoleId { get; set; }
        public int FkUserTypeId { get; set; }        
        public virtual ICollection<Address> AddressFkUsers { get; set; } = new List<Address>();       
        public virtual ICollection<Cart> CartFkUsers { get; set; } = new List<Cart>();        
        public virtual User CreatedBy { get; set; } = null!;      
        public virtual Role FkRole { get; set; } = null!;
        public virtual UserType FkUserType { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual ICollection<Order> OrderFkUsers { get; set; } = new List<Order>();      
        public virtual ICollection<Payment> PaymentFkUsers { get; set; } = new List<Payment>();
        public virtual ICollection<RefreshToken> RefreshTokenFkUsers { get; set; } = new List<RefreshToken>();

        //public virtual ICollection<Order> OrderModifiedBies { get; set; } = new List<Order>();
        //public virtual ICollection<Address> AddressCreatedBies { get; set; } = new List<Address>();
        //public virtual ICollection<Address> AddressModifiedBies { get; set; } = new List<Address>();
        //public virtual ICollection<Cart> CartCreatedBies { get; set; } = new List<Cart>();
        //public virtual ICollection<User> InverseCreatedBy { get; set; } = new List<User>();
        //public virtual ICollection<User> InverseModifiedBy { get; set; } = new List<User>();
        //public virtual ICollection<ItemCategory> ItemCategoryCreatedBies { get; set; } = new List<ItemCategory>();
        //public virtual ICollection<ItemCategory> ItemCategoryModifiedBies { get; set; } = new List<ItemCategory>();
        //public virtual ICollection<Item> ItemCreatedBies { get; set; } = new List<Item>();
        //public virtual ICollection<Item> ItemModifiedBies { get; set; } = new List<Item>();
        //public virtual ICollection<ItemPrice> ItemPriceCreatedBies { get; set; } = new List<ItemPrice>();
        //public virtual ICollection<ItemPrice> ItemPriceModifiedBies { get; set; } = new List<ItemPrice>();
        //public virtual ICollection<Logistic> LogisticCreatedBies { get; set; } = new List<Logistic>();
        //public virtual ICollection<Logistic> LogisticModifiedBies { get; set; } = new List<Logistic>();
        //public virtual ICollection<Discount> DiscountCreatedBies { get; set; } = new List<Discount>();
        //public virtual ICollection<Discount> DiscountModifiedBies { get; set; } = new List<Discount>();
        //public virtual ICollection<Order> OrderCreatedBies { get; set; } = new List<Order>();
        //public virtual ICollection<Cart> CartModifiedBies { get; set; } = new List<Cart>();
        //public virtual ICollection<OrderStatus> OrderStatusCreatedBies { get; set; } = new List<OrderStatus>();
        //public virtual ICollection<OrderStatus> OrderStatusModifiedBies { get; set; } = new List<OrderStatus>();
        //public virtual ICollection<Payment> PaymentCreatedBies { get; set; } = new List<Payment>();
        //public virtual ICollection<PaymentMode> PaymentModeCreatedBies { get; set; } = new List<PaymentMode>();
        //public virtual ICollection<PaymentMode> PaymentModeModifiedBies { get; set; } = new List<PaymentMode>();
        //public virtual ICollection<Payment> PaymentModifiedBies { get; set; } = new List<Payment>();
        //public virtual ICollection<Promotion> PromotionCreatedBies { get; set; } = new List<Promotion>();
        //public virtual ICollection<Promotion> PromotionModifiedBies { get; set; } = new List<Promotion>();
        //public virtual ICollection<RefreshToken> RefreshTokenCreatedBies { get; set; } = new List<RefreshToken>();
        //public virtual ICollection<Refund> RefundCreatedBies { get; set; } = new List<Refund>();
        //public virtual ICollection<Refund> RefundModifiedBies { get; set; } = new List<Refund>();
        //public virtual ICollection<Return> ReturnCreatedBies { get; set; } = new List<Return>();
        //public virtual ICollection<Return> ReturnModifiedBies { get; set; } = new List<Return>();
        //public virtual ICollection<Role> RoleCreatedBies { get; set; } = new List<Role>();
        //public virtual ICollection<Role> RoleModifiedBies { get; set; } = new List<Role>();
        //public virtual ICollection<Unit> UnitCreatedBies { get; set; } = new List<Unit>();
        //public virtual ICollection<Unit> UnitModifiedBies { get; set; } = new List<Unit>();
        //public virtual ICollection<UserLogin> UserLoginCreatedBies { get; set; } = new List<UserLogin>();
        //public virtual ICollection<UserType> UserTypeCreatedBies { get; set; } = new List<UserType>();
        //public virtual ICollection<UserType> UserTypeModifiedBies { get; set; } = new List<UserType>();
    }
}
