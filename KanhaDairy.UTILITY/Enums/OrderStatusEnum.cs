using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.UTILITY.Enums
{
    public enum OrderStatusEnum
    { 
        Pending = 1,
        Processing = 2,
        OrderPlaced = 3,
        Confirmed = 4,
        Delivered = 5,
        Cancelled = 6
    }
}
