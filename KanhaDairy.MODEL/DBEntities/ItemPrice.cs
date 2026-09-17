using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class ItemPrice : SoftDeleteEntity
    {
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public int FkItemId { get; set; }        
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual Item FkItem { get; set; } = null!;
    }
}