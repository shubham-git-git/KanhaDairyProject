using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.OrderStatusDTOs
{
    public class OrderStatusDto : SoftDeleteEntity
    {
        public int OrderStatusId { get; set; }
        public string Status { get; set; } = null!;        
    }
}
