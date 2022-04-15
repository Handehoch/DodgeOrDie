﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace DodgeOrDie.Models.Timer
{
    //нормально ли такое наследование, если GameTimer отвечает не только за измерение времени, но и отображение его на экране
    internal class Watch: Stopwatch 
    {
        public Pen Pen { get; private set; }
        public Size Size { get; private set; }
        public Point StartPos { get; private set; }
        public Point EndPos 
        { 
            get => new Point(StartPos.X + Size.Width, StartPos.Y + Size.Height); 
        }
        public Rectangle Rectangle { get; private set; }
        public Font Font { get; private set; }
        public Time Time { get; private set; }

        public Watch(Pen pen, /*Font font,*/ int width, int height, int x, int y)
        {
            Pen = pen;
            Time = new Time(Size.Width, Size.Height, StartPos.X, StartPos.Y);
            Update(width, height, x, y);
        }

        internal void Update(int width, int height, int x, int y)
        {
            Size = new Size((int)(width * 0.15), (int)(height * 0.10));
            StartPos = new Point(x - Size.Width , y - Size.Height);
            Rectangle = new Rectangle(StartPos, Size);
            Font = new Font(FontFamily.GenericSansSerif, (width + height) / 100, FontStyle.Bold);
            Time.Update(Size.Width, Size.Height, StartPos.X, StartPos.Y);
        }

        internal string MeasureTime()
        {
            var t = TimeSpan.FromMilliseconds(ElapsedMilliseconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                t.Hours, t.Minutes, t.Seconds);
        }
    }
}