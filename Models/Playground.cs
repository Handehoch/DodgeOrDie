using System.Drawing;
using DodgeOrDie.Entities;

namespace DodgeOrDie.Models
{
    internal class Playground: IScreenDetail
    {
        public Player Player { get; set; }
        public Pen Pen { get; set; }
        public Size Size { get; set; }
        public Point StartPos { get; set; }
        public Point EndPos => new Point(StartPos.X + Size.Width, StartPos.Y + Size.Height);
        public Rectangle Rectangle { get; set; }

        private const double Scale = 0.6;
        public Playground(Pen pen, int width, int height)
        {
            Pen = pen;
            Player = new Player(width, height);
            Update(width, height, 0, 0);
        }

        public void Update(int width, int height, int x, int y)
        {
            Size = new Size((int)(Scale * width), (int)(Scale * height));
            StartPos = new Point((width - Size.Width) / 2, (height - Size.Height) / 2);
            Rectangle = new Rectangle(StartPos, Size);
            Player.Update(EndPos.X, EndPos.Y);
        }

        public void TryMoveCharacter()
        {
            Player.GoLeft = Player.X - 2 * Pen.Width > StartPos.X;
            Player.GoRight = Player.X + 2 * Pen.Width + Player.Size < EndPos.X;
            Player.GoUp = Player.Y - 2 * Pen.Width > StartPos.Y;
            Player.GoDown = Player.Y + 2 * Pen.Width + Player.Size < EndPos.Y;
        }

        public override string ToString()
        {
            return string.Format($"Start: X={StartPos.X} Y={StartPos.Y} End: X={EndPos.X} Y={EndPos.Y}");
        }
    }
}
