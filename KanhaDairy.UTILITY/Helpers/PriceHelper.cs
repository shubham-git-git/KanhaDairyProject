using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanhaDairy.UTILITY.Helpers
{
    public static class PriceHelper
    {
        public static double CalculateTotal(int count, double price)
        {
            return count * price;
        }
    }
}
