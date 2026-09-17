using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.ItemDTOs
{
    public class UpdateItemDto 
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int FkUnitId { get; set; }
        public int FkCategoryId { get; set; }
        public bool IsActive { get; set; }

    }
}
