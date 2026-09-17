using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Refund: SoftDeleteEntity
    {
        public int RefundId { get; set; }
        public int FkOrderId { get; set; }
        public int FkItemId { get; set; }
        public DateTime RefundDate { get; set; }
        public decimal RefundAmount { get; set; }
        public bool? RefundStatus { get; set; }
        public string? Remark { get; set; }  
        public virtual User CreatedBy { get; set; } = null!;
        public virtual Item FkItem { get; set; } = null!;
        public virtual Order FkOrder { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
    }
}