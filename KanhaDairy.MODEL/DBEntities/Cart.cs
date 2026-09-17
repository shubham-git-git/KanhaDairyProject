using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Cart: AuditEntity
    {
        public int CartId { get; set; }
        public int FkUserId { get; set; } 
        public int FkItemId { get; set; } 
        public int Quantity { get; set; } 
        public int? FkDiscountId { get; set; }
        public decimal PricePerUnit { get; set; } 
        public decimal TotalPrice { get; set; }  
        public bool IsActive { get; set; }  
        public virtual User CreatedBy { get; set; } = null!;
        public virtual Item FkItem { get; set; } = null!;
        public virtual User FkUser { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
    }
}
