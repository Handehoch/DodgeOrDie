using System.Drawing.Text;
using System.IO;
using System.Reflection;
using DodgeOrDie.Models;
using DodgeOrDie.Entities;

namespace DodgeOrDie.Helpers
{
    internal static class Extensions
    {
        public static bool IsInsideBounds(this System.Windows.Vector point, int width, int height)
        {
            return point.X >= 0 && point.Y >= 0 && point.X < width && point.Y < height;
        }

        public static bool InteractsWith(this Player entity, IEnemy other) 
        {
            var character = entity as Player;
            return character.X <= other.X + other.Size.Width 
                && character.X + character.Size >= other.X
                && character.Y <= other.Y + other.Size.Height
                && character.Y + character.Size >= other.Y;
        }

        public static void AddFontFromMemory(this PrivateFontCollection pfc, string location)
        {
            Stream fontStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream(location);

            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            fontStream.Close();

            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    pfc.AddMemoryFont((System.IntPtr)pFontData, fontData.Length);
                }
            }
        }
    }
}
