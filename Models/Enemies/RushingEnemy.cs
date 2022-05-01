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
        public int Speed { get; set; }
        public int Size { get; set; }
        public Image Sprite { get; set; }

        public RushingEnemy(int x, int y)
        {
            
            Sprite = new Bitmap(@"C:\Users\boris\source\repos\DodgeOrDie\DodgeOrDie\Sprites\rushingEnemy.png");
        }

        public void Move(int dx, int dy)
        {
            X += dx * (int)Speed;
            Y += dy * (int)Speed;
        }
    }
}
