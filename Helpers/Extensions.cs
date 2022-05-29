using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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

        public static bool InteractsWith(this Character entity, IEnemy other) /*where T : Character, IEnemy*/
        {
            //if(entity is Character)
            //{
                var character = entity as Character;
                return character.X <= other.X + other.Size.Width 
                    && character.X + character.Size >= other.X
                    && character.Y <= other.Y + other.Size.Height
                    && character.Y + character.Size >= other.Y;
            //}
            //else if(entity is IEnemy)
            //{
            //    var enemy = entity as IEnemy;
            //    return enemy.X < other.X + other.Size.Width
            //        && enemy.X + enemy.Size.Width < other.X
            //        && enemy.Y > other.Y + other.Size.Height
            //        && enemy.Y + enemy.Size.Height < other.Y;
            //}

            //return false;
        }
    }
}
