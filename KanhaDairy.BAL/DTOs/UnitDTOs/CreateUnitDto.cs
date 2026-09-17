using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.UnitDTOs
{
    public class CreateUnitDto
    {  
        public string UnitName { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
    }
}
