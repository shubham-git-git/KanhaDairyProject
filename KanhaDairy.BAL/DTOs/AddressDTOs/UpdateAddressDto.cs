using KanhaDairy.MODEL.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.BAL.DTOs.AddressDTOs
{
    public class UpdateAddressDto 
    {
        public int AddressId { get; set; }
        public int FkUserId { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Country { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
