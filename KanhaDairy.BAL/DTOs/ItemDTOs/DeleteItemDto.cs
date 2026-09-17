using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.ItemDTOs
{
    public class DeleteItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
    }
}
