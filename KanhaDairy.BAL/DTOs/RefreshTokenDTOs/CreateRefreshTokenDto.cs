using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.RefreshTokenDTOs
{
    public class CreateRefreshTokenDto
    {
        public int TokenId { get; set; }
        public int FkUserId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiryTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
    }
}
