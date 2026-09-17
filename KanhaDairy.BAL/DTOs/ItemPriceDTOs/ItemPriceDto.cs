using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.ItemPriceDTOs
{
    public class ItemPriceDto : SoftDeleteEntity
    {
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public int FkItemId { get; set; }
    }
}
