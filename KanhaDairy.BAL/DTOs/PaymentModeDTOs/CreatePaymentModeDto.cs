using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.PaymentModeDTOs
{
    public class CreatePaymentModeDto
    {
        public int PaymentModeId { get; set; }
        public string PayMode { get; set; } = null!;
    }
}
