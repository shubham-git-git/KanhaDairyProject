using KanhaDairy.UTILITY.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.MODEL.DBEntities
{
    public class LogisticStatus
    {
        public int LogisticStatusId { get; set; }
        public int FkLogisticId { get; set; }  
        public DeliveryStatusEnum Status { get; set; } 
        public DateTime StatusTime { get; set; }
        public virtual Logistic Logistic { get; set; } = null!;
    }
}
