using DodgeOrDie.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeOrDie.Models
{
    internal class Blank : IScreenDetail
    {
        public Size Size { get; set; }
        public Point StartPos { get; set; }
        public Point EndPos => new Point(StartPos.X + Size.Width, StartPos.Y + Size.Height);
        public Rectangle Rectangle { get; set; }

        public readonly Image Sprite;

        public Blank(int x, int y)
        {
            Size = new Size(30, 26);
            Sprite = new Bitmap(@"C:..\..\..\DodgeOrDie\Sprites\blank.png");
            Update(0, 0, x, y);
        }

        public void Update(int width, int height, int x, int y)
        {
            StartPos = new Point(x, y);
            Rectangle = new Rectangle(StartPos, Size);
        }
    }
}
