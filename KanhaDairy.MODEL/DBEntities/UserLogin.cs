using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class UserLogin :SoftDeleteEntity
    {
        public int LoginId { get; set; }
        public int FkUserId { get; set; }
        public string PasswordHash { get; set; } = null!;
        public int? LoginAttempts { get; set; }
        public bool IsLocked { get; set; }      
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
    }
}