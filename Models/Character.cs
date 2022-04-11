using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1.Models
{
    internal class Character
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Speed { get; private set; }

        public readonly Image Sprite;
        public readonly int Size = 32;

        public Character(int x, int y)
        {
            Update(x, y);
            Sprite = new Bitmap(@"C:\Users\boris\source\repos\DodgeOrDie\DodgeOrDie\Sprites\redHeart.png");
        }

        public void Update(int x, int y)
        {
            X = x / 2;
            Y = y / 2;
            Speed = (x + y) / 200;
        }

        public void Move(double dx, double dy)
        {
            //if (dx == double.NaN || dy == double.NaN) return;
            X += (int)dx * Speed;
            Y += (int)dy * Speed;
        }
    }
}
