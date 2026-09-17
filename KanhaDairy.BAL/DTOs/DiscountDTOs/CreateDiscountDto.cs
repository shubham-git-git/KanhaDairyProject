using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.DiscountDTOs
{
    public class CreateDiscountDto
    {
        public int DiscountId { get; set; }
        public int FkItemId { get; set; }
        public string DiscountName { get; set; } = null!;
        public string DiscountType { get; set; } = null!;
        public string DiscountValue { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
