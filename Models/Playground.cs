using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeOrDie.Entities;

namespace DodgeOrDie.Models
{
    internal class Playground: IScreenDetail
    {
        //Все сеттеры должны быть private, но c# 7.3 не позволяет
        public Character Character { get; set; }
        public Pen Pen { get; set; }
        public Size Size { get; set; }
        public Point StartPos { get; set; }
        public Point EndPos
        {
            get => new Point(StartPos.X + Size.Width, StartPos.Y + Size.Height);
        }
        public Rectangle Rectangle { get; set; }

        private const double Scale = 0.6;
        public Playground(Pen pen, int width, int height)
        {
            Pen = pen;
            Character = new Character(width, height);
            Update(width, height, 0, 0);
        }

        public void Update(int width, int height, int x, int y)
        {
            Size = new Size((int)(Scale * width), (int)(Scale * height));
            StartPos = new Point((width - Size.Width) / 2, (height - Size.Height) / 2);
            Rectangle = new Rectangle(StartPos, Size);
            Character.Update(EndPos.X, EndPos.Y);
        }

        public void TryMove()
        {
            Character.GoLeft = Character.X - 2 * Pen.Width > StartPos.X;
            Character.GoRight = Character.X + 2 * Pen.Width + Character.Size < EndPos.X;
            Character.GoUp = Character.Y - 2 * Pen.Width > StartPos.Y;
            Character.GoDown = Character.Y + 2 * Pen.Width + Character.Size < EndPos.Y;
        }

        public override string ToString()
        {
            return string.Format($"Start: X={StartPos.X} Y={StartPos.Y} End: X={EndPos.X} Y={EndPos.Y}");
        }
    }
}
