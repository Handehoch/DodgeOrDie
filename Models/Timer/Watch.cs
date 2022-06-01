using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using DodgeOrDie.Entities;

namespace DodgeOrDie.Models.Timer
{
    internal class Watch: Stopwatch, IScreenDetail
    {
        public Pen Pen { get; set; }
        public Size Size { get; set; }
        public Point StartPos { get; set; }
        public Point EndPos 
        { 
            get => new Point(StartPos.X + Size.Width, StartPos.Y + Size.Height); 
        }
        public Rectangle Rectangle { get; set; }
        public Font Font { get; private set; }
        public Time Time { get; private set; }

        private readonly PrivateFontCollection _fc;
        public Watch(Pen pen, /*Font font,*/ int width, int height, int x, int y)
        {
            Pen = pen;
            Time = new Time(Size.Width, Size.Height, StartPos.X, StartPos.Y);
            _fc = new PrivateFontCollection();
            _fc.AddFontFile(@"..\..\..\DodgeOrDie\Sprites\HalfBoldPixel7-2rw3.ttf");
            Update(width, height, x, y);
        }

        public void Update(int width, int height, int x, int y)
        {
            Size = new Size((int)(width * 0.15), (int)(height * 0.10));
            StartPos = new Point(x - Size.Width , y - Size.Height);
            Rectangle = new Rectangle(StartPos, Size);
            Font = new Font(_fc.Families[0], (width + height) / 100, FontStyle.Bold);
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
