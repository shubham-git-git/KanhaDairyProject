using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Logistic : SoftDeleteEntity
    {
        public int LogisticId { get; set; }
        //public int FkOrderId { get; set; } 
        public int FkDeliverById { get; set; } 
        public DateTime DeliveredTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public int FkDeleveryStatusId { get; set; }
        public string? Comments { get; set; }             
        public string? VehicleNumber { get; set; }  
        public virtual User CreatedBy { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<LogisticStatus> LogisticStatuses { get; set; } = new List<LogisticStatus>();
        
    }
}
