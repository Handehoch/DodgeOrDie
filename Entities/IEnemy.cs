using System.Drawing;

namespace DodgeOrDie.Entities
{
    internal interface IEnemy
    {
        double X { get; set; }
        double Y { get; set; }
        System.Windows.Vector Location { get; set; }
        Size Size { get; set; }
        Image Sprite { get; set; }
        void Move(int speed);
        void Appear(int x, int y);
    }
}
