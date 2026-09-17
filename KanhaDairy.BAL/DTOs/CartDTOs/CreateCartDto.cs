using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.CartDTOs
{
    public class CreateCartDto
    {
        //public int CartId { get; set; }
        public int FkUserId { get; set; }
        public int FkItemId { get; set; }
        public int Quantity { get; set; }
        public int? FkDiscountId { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
