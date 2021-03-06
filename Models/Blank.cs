using System.Drawing;
using DodgeOrDie.Entities;

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
            Sprite = Properties.Resources.blank;
            Update(0, 0, x, y);
        }

        public void Update(int width, int height, int x, int y)
        {
            StartPos = new Point(x, y);
            Rectangle = new Rectangle(StartPos, Size);
        }
    }
}
