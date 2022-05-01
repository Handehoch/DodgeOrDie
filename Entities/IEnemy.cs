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
        int Speed { get; set; }
        int Size { get; set; }
        Image Sprite { get; set; }
        void Move(int dx, int dy);
    }
}
