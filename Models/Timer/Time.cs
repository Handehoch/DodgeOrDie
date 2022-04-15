using DodgeOrDie.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgeOrDie.Models.Timer
{
    internal class Time: IScreenDetail
    {
        public Size Size { get; set; }
        public Point StartPos { get; set; }
        public Point EndPos
        {
            get => new Point((int)StartPos.X + Size.Width, (int)StartPos.Y + Size.Height);
        }
        public Brush Brush { get; set; }
        public Rectangle Rectangle { get; set; }

        public Time(int width, int height, int x, int y)
        {
            Brush = new SolidBrush(Color.White);
            Update(width, height, x, y);
        }

        public void Update(int width, int height, int x, int y)
        {
            Size = new Size((int)(0.15 * width), (int)(0.15 * height));
            StartPos = new Point((int)((width - Size.Width) / 4.2) + x, (height - Size.Height) / 3 + y);
            Rectangle = new Rectangle(StartPos, Size);
        }
    }
}
