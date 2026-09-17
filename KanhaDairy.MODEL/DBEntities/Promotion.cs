using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Promotion : SoftDeleteEntity
    {
        public int PromotionId { get; set; }
        public string? Promotiontext { get; set; }
        public string? Promotionlog { get; set; }       
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
    }
}
