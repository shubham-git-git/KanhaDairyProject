using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.ReturnDTOs
{
    public class CreateReturnDto
    {
        public int ReturnId { get; set; }
        public string ReturnRegion { get; set; } = null!;
        public string? Comment { get; set; }      
    }
}
