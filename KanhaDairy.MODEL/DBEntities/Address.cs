using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Address: SoftDeleteEntity
    {
        public int AddressId { get; set; }
        public int FkUserId { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;     
        public virtual User CreatedBy { get; set; } = null!;        
        public virtual User FkUser { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
    }
}
