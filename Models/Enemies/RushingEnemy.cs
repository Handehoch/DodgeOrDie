using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DodgeOrDie.Entities;

namespace DodgeOrDie.Models.Enemies
{
    internal class RushingEnemy : IEnemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        //public Point Location { get; set; }
        public Size Size { get; set; }
        public Image Sprite { get; set; }
        public Point Direction { get; set; }

        public RushingEnemy()
        {
            Size = new Size(56, 45);
            Sprite = new Bitmap(@"C:\Users\boris\source\repos\DodgeOrDie\DodgeOrDie\Sprites\rushingEnemy.png");
        }

        public void Move(int speed)
        {
            X += Direction.X * speed;
            Y += Direction.Y * speed;
            //Location = new Point(X, Y);
        }

        public void Appear(int x, int y)
        {
            X = x;
            Y = y;
            //Location = new Point(X, Y);
        }

        public void SetDirection(Point direction)
        {
            Direction = direction;
        }
    }
}
