using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.PaymentDTOs
{
    public class UpdatePaymentDto 
    {
        public int PaymentId { get; set; }
        public int FkOrderId { get; set; }
        public int FkUserId { get; set; }
        public int FkPaymentModeId { get; set; }
        public string TransactionId { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
