using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DodgeOrDie.Models;

namespace DodgeOrDie.Helpers
{
    internal static class Extensions
    {
        public static bool IsOutOfBounds(this Point point, int width, int height)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < width && point.Y < height;
        }
    }
}
