using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeOrDie.Helpers
{
    internal static class Extensions
    {
        public static bool EqualsTo(this float value1, float value2, float epsilon)
        {
            return Math.Abs(value1 - value2) < epsilon;
        }
    }
}
