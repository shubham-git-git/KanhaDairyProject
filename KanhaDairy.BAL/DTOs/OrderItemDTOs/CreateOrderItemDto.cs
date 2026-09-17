using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.OrderItemDTOs
{
    public class CreateOrderItemDto
    {
        public int OrderItemId { get; set; }
        public int FkOrderId { get; set; }
        public int FkItemId { get; set; }
        public int Quantity { get; set; }
        public int? FkDiscountId { get; set; }
        public decimal Price { get; set; }
    }
}
