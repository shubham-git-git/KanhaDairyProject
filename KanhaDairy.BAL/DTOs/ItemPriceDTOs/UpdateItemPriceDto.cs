using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.ItemPriceDTOs
{
    public class UpdateItemPriceDto 
    {
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public int FkItemId { get; set; }
        public bool IsActive { get; set; }


    }
}
