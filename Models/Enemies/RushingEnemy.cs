using System.Drawing;
using DodgeOrDie.Entities;

namespace DodgeOrDie.Models.Enemies
{
    internal class RushingEnemy : IEnemy
    {
        public double X { get; set; }
        public double Y { get; set; }
        public System.Windows.Vector Location { get; set; }
        public Size Size { get; set; }
        public Image Sprite { get; set; }
        public System.Windows.Vector Direction { get; set; }

        public RushingEnemy()
        {
            Size = new Size(56, 45);
            Sprite = Properties.Resources.rushingEnemy;
        }

        public void Move(int speed)
        {
            X += Direction.X * speed;
            Y += Direction.Y * speed;
            Location = new System.Windows.Vector(X, Y);
        }

        public void Appear(int x, int y)
        {
            X = x;
            Y = y;
            Location = new System.Windows.Vector(X, Y);
        }

        public void SetDirection(System.Windows.Vector direction)
        {
            Direction = direction;
        }
    }
}
