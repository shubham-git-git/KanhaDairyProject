using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.UserDTOs
{
    public class UserDto : SoftDeleteEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; } 
        public int? CountryCode { get; set; }
        public string Mobile { get; set; } = null!;
        public int FkRoleId { get; set; }
        public int FkUserTypeId { get; set; }      
    }
}
