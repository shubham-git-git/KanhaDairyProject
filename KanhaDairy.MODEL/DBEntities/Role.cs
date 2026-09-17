using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Role: SoftDeleteEntity
    {
        public int RoleId { get; set; }
        public string Roles { get; set; } = null!;      
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
