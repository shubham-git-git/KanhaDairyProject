using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Payment: SoftDeleteEntity
    {
        public int PaymentId { get; set; }
        public int FkOrderId { get; set; }
        public int FkUserId { get; set; }
        public int FkPaymentModeId { get; set; }
        public string TransactionId { get; set; } = null!;     
        public virtual User CreatedBy { get; set; } = null!;
        public virtual Order FkOrder { get; set; } = null!;
        public virtual PaymentMode FkPaymentMode { get; set; } = null!;
        public virtual User FkUser { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
    }
}
