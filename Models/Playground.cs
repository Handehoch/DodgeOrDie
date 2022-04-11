using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    internal class Playground
    {
        public Character Character { get; private set; }
        public Pen Pen { get; private set; }
        public Size Size { get; private set; }
        public Point StartPos { get; private set; }
        public Point EndPos
        {
            get { return new Point(StartPos.X + Size.Width, StartPos.Y + Size.Height); }
        }

        public Rectangle Rectangle { get; private set; }
        public Playground(Pen pen, int width, int height)
        {
            Pen = pen;
            Character = new Character(Size.Width, Size.Height);
            Update(width, height);
        }

        public void Update(int width, int height)
        {
            StartPos = new Point((width - (int)(width * 0.6)) / 2, (height - (int)(height * 0.6)) / 2);
            Size = new Size((int)(0.6 * width), (int)(0.6 * height));
            Rectangle = new Rectangle(StartPos, Size);
            Character.Update(Size.Width, Size.Height);
        }

        public override string ToString()
        {
            return string.Format($"Start: X={StartPos.X} Y={StartPos.Y} End: X={EndPos.X} Y={EndPos.Y}");
        }

        public bool IsPlayerOnPlayground()
        {
            return Character.X - 12 > StartPos.X
                && Character.Y - 12 > StartPos.Y
                && Character.X + 12 + Character.Size < EndPos.X
                && Character.Y + 12 + Character.Size < EndPos.Y;
        }
    }
}
