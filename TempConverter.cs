using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJS.Temperature.BL
{
    public static class TempConverter
    {
        public static double ConvertToC(double fahrenheit)
        {
            return 5.0 / 9.0 * (fahrenheit - 32);
        }

        public static double ConvertToF(double celsius)
        {
            return 9.0 / 5.0 * celsius + 32;
        }



    }
}
