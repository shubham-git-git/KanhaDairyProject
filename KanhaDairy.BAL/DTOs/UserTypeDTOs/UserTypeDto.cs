using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.UserTypeDTOs
{
    public class UserTypeDto : SoftDeleteEntity
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; } = null!;
    }
}
