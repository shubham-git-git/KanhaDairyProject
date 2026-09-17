using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Item : SoftDeleteEntity
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int FkUnitId { get; set; }
        public int FkCategoryId { get; set; }           
        public virtual User CreatedBy { get; set; } = null!;        
        public virtual ItemCategory FkCategory { get; set; } = null!;
        public virtual Unit FkUnit { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();
        public virtual ICollection<OrderItems> OrderItems { get; set; }=new List<OrderItems>();
    }
}
