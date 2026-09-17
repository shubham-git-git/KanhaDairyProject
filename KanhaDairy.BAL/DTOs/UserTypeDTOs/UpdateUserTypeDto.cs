using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.UserTypeDTOs
{
    public class UpdateUserTypeDto 
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; } = null!;
        public bool IsActive { get; set; }

    }
}
