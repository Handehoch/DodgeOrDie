using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeOrDie.Helpers;

namespace DodgeOrDie.Models
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

        private const double Scale = 0.6;
        public Playground(Pen pen, int width, int height)
        {
            Pen = pen;
            Character = new Character(width, height);
            Update(width, height);
        }

        public void Update(int width, int height)
        {
            Size = new Size((int)(Scale * width), (int)(Scale * height));
            StartPos = new Point((width - Size.Width) / 2, (height - Size.Height) / 2);
            Rectangle = new Rectangle(StartPos, Size);
            Character.Update(EndPos.X, EndPos.Y);
        }

        public void TryMove(/*System.Windows.Vector direction*/)
        {
            Character.GoLeft = Character.X - 2 * Pen.Width > StartPos.X;
            Character.GoRight = Character.X + 2 * Pen.Width + Character.Size < EndPos.X;
            Character.GoUp = Character.Y - 2 * Pen.Width > StartPos.Y;
            Character.GoDown = Character.Y + 2 * Pen.Width + Character.Size < EndPos.Y;

            //var newPosition = new PointF((float)(Character.X + direction.X), (float)(Character.Y + direction.Y));

            //return newPosition.X.EqualsTo(StartPos.X, Pen.Width * 2)
            //    || newPosition.X.EqualsTo(EndPos.X, Pen.Width * 2 + Character.Size)
            //    || newPosition.Y.EqualsTo(StartPos.Y, Pen.Width * 2)
            //    || newPosition.Y.EqualsTo(EndPos.Y, Pen.Width * 2 + Character.Size);
        }

        public override string ToString()
        {
            return string.Format($"Start: X={StartPos.X} Y={StartPos.Y} End: X={EndPos.X} Y={EndPos.Y}");
        }
    }
}
