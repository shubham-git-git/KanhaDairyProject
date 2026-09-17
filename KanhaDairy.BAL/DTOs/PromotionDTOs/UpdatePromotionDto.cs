using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.PromotionDTOs
{
    public class UpdatePromotionDto
    {
        public int PromotionId { get; set; }
        public string? Promotiontext { get; set; }
        public string? Promotionlog { get; set; }
        public bool IsActive { get; set; }

    }
}
