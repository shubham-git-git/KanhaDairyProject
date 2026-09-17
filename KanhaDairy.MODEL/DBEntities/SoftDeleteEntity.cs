using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.MODEL.DBEntities
{
    public abstract class SoftDeleteEntity: AuditEntity
    {
        public bool IsActive { get; set; } = true;

        
    }
    public abstract class AuditEntity
    {
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedById { get; set; }


    }
}
