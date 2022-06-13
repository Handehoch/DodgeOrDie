using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows;
using DodgeOrDie.Models;

namespace DodgeOrDie.Controllers
{
    internal static class PlayerMovement
    {
        private static readonly List<Keys> Keys = new List<Keys>();

        public static void Clear()
        {
            Keys.Clear();
        }

        public static void AddKey(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode) && !Keys.Contains(e.KeyCode))
                Keys.Add(e.KeyCode);
        }

        public static void RemoveKey(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode) && Keys.Contains(e.KeyCode))
                Keys.Remove(e.KeyCode);
        }

        private static bool IsValidKey(Keys key)
        {
            return key == System.Windows.Forms.Keys.W 
                   || key == System.Windows.Forms.Keys.S 
                   || key == System.Windows.Forms.Keys.A 
                   || key == System.Windows.Forms.Keys.D;
        }

        public static Vector GetDirection(Player character, bool isInverted)
        {
            if (Keys.Count == 0) return new Vector(0, 0);

            var resDirection = new Vector();
            foreach (var key in Keys)
            {
                var direction = isInverted 
                    ? GetInvertedDirectionByKey(key, character) 
                    : GetDirectionByKey(key, character);

                resDirection.X += direction.X;
                resDirection.Y += direction.Y;
            }

            return resDirection;
        }

        public static Point GetDirectionByKey(Keys key, Player character)
        {
            switch (key)
            {
                case System.Windows.Forms.Keys.W when character.GoUp:
                    return new Point(0, -1);
                case System.Windows.Forms.Keys.S when character.GoDown:
                    return new Point(0, 1);
                case System.Windows.Forms.Keys.A when character.GoLeft:
                    return new Point(-1, 0);
                case System.Windows.Forms.Keys.D when character.GoRight:
                    return new Point(1, 0);
                default:
                    return new Point(0, 0);
            }
        }

        public static Point GetInvertedDirectionByKey(Keys key, Player character)
        {
            switch (key)
            {
                case System.Windows.Forms.Keys.S when character.GoUp:
                    return new Point(0, -1);
                case System.Windows.Forms.Keys.W when character.GoDown:
                    return new Point(0, 1);
                case System.Windows.Forms.Keys.D when character.GoLeft:
                    return new Point(-1, 0);
                case System.Windows.Forms.Keys.A when character.GoRight:
                    return new Point(1, 0);
                default:
                    return new Point(0, 0);
            }
        }
    }
}
