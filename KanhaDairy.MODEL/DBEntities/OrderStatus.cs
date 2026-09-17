using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class OrderStatus: SoftDeleteEntity
    {
        public int OrderStatusId { get; set; }
        public string Status { get; set; } = null!;     
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
