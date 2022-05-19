using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DodgeOrDie.Entities
{
    internal interface IEnemy
    {
        int X { get; set; }
        int Y { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }
        Image Sprite { get; set; }
        void Move(int speed);
        void Appear(int x, int y);
    }
}
