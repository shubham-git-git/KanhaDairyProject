using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class PaymentMode: SoftDeleteEntity
    {
        public int PaymentModeId { get; set; }
        public string PayMode { get; set; } = null!;       
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}