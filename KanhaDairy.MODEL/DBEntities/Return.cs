using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Return : SoftDeleteEntity
    {
        public int ReturnId { get; set; }
        public string ReturnRegion { get; set; } = null!;
        public string? Comment { get; set; }        
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
    }
}
