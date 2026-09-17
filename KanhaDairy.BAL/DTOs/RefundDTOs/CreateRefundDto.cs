using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.RefundDTOs
{
    public class CreateRefundDto
    {
        public int RefundId { get; set; }
        public int FkOrderId { get; set; }
        public int FkItemId { get; set; }
        public DateTime RefundDate { get; set; }
        public decimal RefundAmount { get; set; }
        public bool? RefundStatus { get; set; }
        public string? Remark { get; set; } 

    }
}
