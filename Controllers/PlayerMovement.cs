using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows;
using DodgeOrDie.Models;

namespace DodgeOrDie.Controllers
{
    internal static class PlayerMovement
    {
        private static readonly List<Keys> _keys = new List<Keys>();

        public static void Clear()
        {
            _keys.Clear();
        }

        public static void AddKey(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode) && !_keys.Contains(e.KeyCode))
                _keys.Add(e.KeyCode);
        }

        public static void RemoveKey(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode) && _keys.Contains(e.KeyCode))
                _keys.Remove(e.KeyCode);
        }

        private static bool IsValidKey(Keys key)
        {
            return key == Keys.W || key == Keys.S || key == Keys.A || key == Keys.D;
        }

        public static Vector GetDirection(Player character, bool isInverted)
        {
            if (_keys.Count == 0) return new Vector(0, 0);

            var resDirection = new Vector();
            foreach (var key in _keys)
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
            if (key == Keys.W && character.GoUp)
                return new Point(0, -1);
            if (key == Keys.S && character.GoDown)
                return new Point(0, 1);
            if (key == Keys.A && character.GoLeft)
                return new Point(-1, 0);
            if (key == Keys.D && character.GoRight)
                return new Point(1, 0);

            return new Point(0, 0);
        }

        public static Point GetInvertedDirectionByKey(Keys key, Player character)
        {
            if (key == Keys.S && character.GoUp)
                return new Point(0, -1);
            if (key == Keys.W && character.GoDown)
                return new Point(0, 1);
            if (key == Keys.D && character.GoLeft)
                return new Point(-1, 0);
            if (key == Keys.A && character.GoRight)
                return new Point(1, 0);

            return new Point(0, 0);
        }
    }
}
