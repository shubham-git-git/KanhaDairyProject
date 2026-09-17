using KanhaDairy.BAL.DTOs.OrderItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.OrderDTOs
{
    public class CreateOrderDto
    {
        public int OrderId { get; set; }
        public int FkUserId { get; set; }
        //public int FkShippingId { get; set; }
        //public int FkBillingId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int FkOrderStatusId { get; set; }
        public bool? PaymentStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? Comment { get; set; }
        //public List<CreateOrderItemDto> OrderItems { get; set; } = new();
    }
}
