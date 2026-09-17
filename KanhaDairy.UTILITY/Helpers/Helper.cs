using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.UTILITY.Helpers
{
    public static class Helper
    {      
        public static DateTime GetCurrentIST()
        {
            return DateTime.UtcNow.AddHours(5.5);
        }
    }
}
