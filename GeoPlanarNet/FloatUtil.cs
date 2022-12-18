using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoPlanarNet
{
    public static class FloatUtil
    {
        public static bool AboutEquals(this float a, float b, float tolerance = 0.001f)
        {
            return Math.Abs(a - b) < tolerance;
        }

        public static bool AboutZero(this float a, float tolerance = 0.001f)
        {
            return Math.Abs(a) < tolerance;
        }
    }
}
