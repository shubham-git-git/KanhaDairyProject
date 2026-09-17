using KanhaDairy.MODEL.DBEntities;

namespace KanhaDairy.BAL.DTOs.UnitDTOs
{
    public class UnitDto: SoftDeleteEntity
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;       
    }
}
