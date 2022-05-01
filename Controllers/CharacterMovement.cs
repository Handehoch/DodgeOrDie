using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows;
using DodgeOrDie.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeOrDie.Controllers
{
    internal static class CharacterMovement
    {
        private static readonly List<Keys> _keys = new List<Keys>();

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
            return key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right;
        }

        public static Vector GetDirection(Character character)
        {
            if (_keys.Count == 0) return new Vector(0, 0);

            var resDirection = new Vector();
            foreach (var key in _keys)
            {
                var direction = GetDirectionByKey(key, character);
                resDirection.X += direction.X;
                resDirection.Y += direction.Y;
            }

            //resDirection.Normalize();
            return resDirection;
        }

        public static Point GetDirectionByKey(Keys key, Character character)
        {
            if (key == Keys.Up && character.GoUp)
                return new Point(0, -1);
            if (key == Keys.Down && character.GoDown)
                return new Point(0, 1);
            if (key == Keys.Left && character.GoLeft)
                return new Point(-1, 0);
            if (key == Keys.Right && character.GoRight)
                return new Point(1, 0);

            return new Point(0, 0);
        }
    }
}
