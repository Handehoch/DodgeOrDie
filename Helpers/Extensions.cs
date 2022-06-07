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
    }
}
