using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Order: AuditEntity
    {
        public int OrderId { get; set; }
        public int FkUserId { get; set; }
        public int? FkLogisticId { get; set; }        
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int FkOrderStatusId { get; set; }
        public bool? PaymentStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? Comment { get; set; }       
        public virtual User CreatedBy { get; set; } = null!;              
        public virtual OrderStatus FkOrderStatus { get; set; } = null!;               
        public virtual User FkUser { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual Billing? Billing { get; set; }
        public virtual Logistic? FkLogistic { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Refund> Refunds { get; set; } = new List<Refund>();
        public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    }
}