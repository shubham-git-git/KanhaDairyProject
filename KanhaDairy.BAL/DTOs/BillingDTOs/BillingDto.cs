using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.BillingDTOs
{
    public class BillingDto : SoftDeleteEntity
    {
        public int BillId { get; set; }
        public DateTime BillDate { get; set; }
        public int FkOrderId { get; set; }
    }
}
