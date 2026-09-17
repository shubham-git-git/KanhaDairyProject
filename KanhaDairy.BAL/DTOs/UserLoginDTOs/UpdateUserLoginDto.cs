using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.UserLoginDTOs
{
    public class UpdateUserLoginDto
    {
        public int LoginId { get; set; }
        public int FkUserId { get; set; }
        public string PasswordHash { get; set; } = null!;
        public int? LoginAttempts { get; set; }
        public bool IsLocked { get; set; }
    }
}
