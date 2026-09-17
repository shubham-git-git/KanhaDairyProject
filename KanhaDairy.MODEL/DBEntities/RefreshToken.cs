using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class RefreshToken
    {
        public int TokenId { get; set; }
        public int FkUserId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiryTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User FkUser { get; set; } = null!;
    }
}
