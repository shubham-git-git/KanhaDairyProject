using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.ItemCategoryDTOs
{
    public class UpdateItemCategoryDto
    {
        public int CategoryId { get; set; }
        public string Category { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
