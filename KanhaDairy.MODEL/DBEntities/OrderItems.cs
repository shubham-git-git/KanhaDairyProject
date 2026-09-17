using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.MODEL.DBEntities
{
    public class OrderItems
    {
        public int OrderItemId { get; set; }
        public int FkOrderId { get; set; }
        public int FkItemId { get; set; }
        public int Quantity { get; set; }
        public int? FkDiscountId { get; set; }
        public decimal Price { get; set; }
        //public virtual Order Order { get; set; } = null!;
        //public virtual Item Item { get; set; } = null!;
        //public virtual Discount? Discount { get; set; }

        // 🔥 navigation property
        public Order FkOrder { get; set; } = null!; 
        public virtual Item FkItem { get; set; } = null!;
        public virtual Discount? FkDiscount { get; set; }
        
    }
}

