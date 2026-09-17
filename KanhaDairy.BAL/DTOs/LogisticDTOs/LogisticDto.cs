using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.LogisticDTOs
{
    public class LogisticDto : SoftDeleteEntity
    {   
        public int LogisticId { get; set; }
        public int FkOrderId { get; set; }
        public int FkDeliverById { get; set; }
        public DateTime DeliveredTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public int FkDeleveryStatusId { get; set; }
        public string? Comments { get; set; }
        public string? VehicleNumber { get; set; }
    }
}
