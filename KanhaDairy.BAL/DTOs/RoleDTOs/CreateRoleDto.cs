using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.RoleDTOs
{
    public class CreateRoleDto
    {
        public int RoleId { get; set; }
        public string Roles { get; set; } = null!;
    }
}
