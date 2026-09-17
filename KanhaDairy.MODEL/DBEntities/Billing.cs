using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Billing: SoftDeleteEntity
    {
        public int BillId { get; set; }
        public DateTime BillDate { get; set; }
        public int FkOrderId { get; set; }             
        public virtual Order FkOrder { get; set; } = null!;        
    }
}

