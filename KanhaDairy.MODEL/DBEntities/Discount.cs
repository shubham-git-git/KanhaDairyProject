using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class Discount : SoftDeleteEntity
    {
        public int DiscountId { get; set; }
        public int FkItemId { get; set; }
        public string DiscountName { get; set; }=null!;
        public string DiscountType { get; set; } = null!;
        public string DiscountValue { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }       
        public virtual User CreatedBy { get; set; } = null!;
        public virtual Item FkItem { get; set; } = null!;
        public virtual User? ModifiedBy { get; set; }
        //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<OrderItems> OrderItems { get; set; }= new List<OrderItems>();
    }
}
