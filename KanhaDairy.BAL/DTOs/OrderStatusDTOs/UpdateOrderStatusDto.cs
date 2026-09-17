using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.OrderStatusDTOs
{
    public class UpdateOrderStatusDto 
    {
        public int OrderStatusId { get; set; }
        public string Status { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedById { get; set; }
    }
}
