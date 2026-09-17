using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.PromotionDTOs
{
    public class CreatePromotionDto
    {
        public int PromotionId { get; set; }
        public string? Promotiontext { get; set; }
        public string? Promotionlog { get; set; }

    }
}
