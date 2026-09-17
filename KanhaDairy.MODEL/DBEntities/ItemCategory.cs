using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities
{
    public partial class ItemCategory: SoftDeleteEntity
    {
        public int CategoryId { get; set; }
        public string Category { get; set; } = null!;       
        public virtual User CreatedBy { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public virtual User? ModifiedBy { get; set; }
    }
}