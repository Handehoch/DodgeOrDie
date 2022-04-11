using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controllers
{
    internal class Movement
    {
        private List<Keys> _keys;

        public Movement()
        {
            _keys = new List<Keys>();
        }

        public void KeyDownMove(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode) && !_keys.Contains(e.KeyCode))
                _keys.Add(e.KeyCode);
        }

        public void KeyUpMove(object sender, KeyEventArgs e)
        {
            if (IsValidKey(e.KeyCode) && _keys.Contains(e.KeyCode))
                _keys.Remove(e.KeyCode);
        }

        private bool IsValidKey(Keys key)
        {
            return key == Keys.Up || key == Keys.Down || key == Keys.Left || key == Keys.Right;
        }

        public Vector GetDirection()
        {
            if (_keys.Count == 0) return new Vector(0, 0);

            var resDirection = new Vector();
            foreach (var key in _keys)
            {
                var direction = GetDirectionByKey(key);
                resDirection.X += direction.X;
                resDirection.Y += direction.Y;
            }

            //resDirection.Normalize();
            return resDirection;
        }

        public Point GetDirectionByKey(Keys key)
        {
            if (key == Keys.Up) return new Point(0, -1);
            if (key == Keys.Down) return new Point(0, 1);
            if (key == Keys.Left) return new Point(-1, 0);
            if (key == Keys.Right) return new Point(1, 0);
            else return new Point(0, 0);
        }
    }
}
