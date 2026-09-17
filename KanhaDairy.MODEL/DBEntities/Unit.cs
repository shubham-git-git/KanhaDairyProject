using System;
using System.Collections.Generic;

namespace KanhaDairy.MODEL.DBEntities

{
    public partial class Unit: SoftDeleteEntity
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;       
        public virtual User CreatedBy { get; set; } = null!;
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public virtual User? ModifiedBy { get; set; }
    }
}
